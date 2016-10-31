using Models.EF;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M1SHOP.Models
{
    public class CartShopping
    {
        public List<M1Product> Items = new List<M1Product>();

        public void Add(int  Id, int soluong)
        {
            try
            {
                var Item = Items.Single(p => p.ID == Id);
                Item.Quantity = Item.Quantity + soluong;
            }
            catch
            {
                DataContextModel db = new DataContextModel();
                var Item = db.M1Product.Single(p => p.ID == Id);
                Item.Quantity = soluong;
                Items.Add(Item);
            }
            
        }
        public void Remove(int Id)
        {
            var Item = Items.Single(p => p.ID == Id);
            Items.Remove(Item);
        }
        public void Update(int Id, int newQuantity)
        {
            var Item = Items.Single(p => p.ID == Id);
            Item.Quantity = newQuantity;
        }
        public void Clear()
        {
            Items.Clear();
        }
        public decimal? Amount
        {
            get
            {
                return Items.Sum(p => p.Price * p.Quantity * (1 - p.Discount));
            }
        }
        public int Count
        {
            get
            {
                return Items.Sum(p => p.Quantity);
            }
        }
        public decimal? tongcong
        {
            get
            {
                decimal? tong = 1;
                foreach(var item in Cart.Items)
                {
                    tong = Cart.Amount;
                }
                return tong;
            }
        }
        public static CartShopping Cart
        {
            get
            {
                var cart = HttpContext.Current.Session["Cart"] as CartShopping;
                if (cart == null)
                {
                    cart = new CartShopping();
                    HttpContext.Current.Session["Cart"] = cart;
                }
                return cart;
            }
        }
    }
}