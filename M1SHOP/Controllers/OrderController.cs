using M1SHOP.Models;
using Models.EF;
using System;
using System.Linq;
using System.Web.Mvc;

namespace M1SHOP.Controllers
{
    
    public class OrderController : dbController
    {
        [XAuthorize]
        public ActionResult Checkout()
        {
            var Customer = Session["User"] as M1Custumers;
            int idOrder = int.Parse(Session["orderID"].ToString());
            ViewBag.Thanhvien = db.M1Custumers.Where(i=>i.ID == idOrder).ToList();
            var model = new M1Orders();
            return View(model);
        }
        [XAuthorize]
        [HttpPost]
        public ActionResult Checkout(M1Orders model)
        {
            //LẤY THÔNG TIN NGƯỜI MUA HÀNG
            int idU = int.Parse(HttpContext.Session["orderID"].ToString());
            var Thanhvien = db.M1Custumers.Find(idU);
            //var Tinhthanhs = db.Tinhthanhs.Find(Thanhvien.idTinhthanh);
            //var thanhpho = Tinhthanhs.Ten;
            /**************************************/
            //TẠO MỘT ĐƠN HÀNG
            model.MaDonHang = DateTime.Now.ToString("yyyyMMddhmmss");
            model.CustomerID = Thanhvien.ID;
            model.CreatedDate = DateTime.Now;
            model.RequireDate = DateTime.Now.AddDays(7);
            model.ShipName = Thanhvien.Name;
            model.ShipAddress = Thanhvien.Address;
            model.ShipMobile = Thanhvien.Phone;
            model.Description = model.Description;
            model.Amount = CartShopping.Cart.tongcong;
            model.Status = 1;
            db.M1Orders.Add(model);
            //THÊM CHỈ TIẾT CÁC MẶT HÀNG
            foreach (var p in CartShopping.Cart.Items)
            {
                var d = new M1OrderDetail
                {
                    Code = p.Code,
                    Name = p.NameWEB,
                    M1Orders = model,
                    UnitPrice = p.Price,
                    Discount = p.Discount,
                    Quantity = p.Quantity,
                    
                };
                db.M1OrderDetail.Add(d);
            }
            db.SaveChanges();
            CartShopping.Cart.Clear(); 
        return RedirectToAction("Hoantat", "Order");

        }
        //XỬ LÝ ĐƠN HÀNG MUA NHANH KHÔNG CẦN ĐĂNG KÝ ACCOUNT
        public ActionResult muanhanh(int id=0)
        {
           
            //Kiểm tra nếu có đăng nhập thì chuyển sang trang AdSLL 
            if (Session["User"] != null)
            {
                return RedirectToAction("AddSL", "Cart");
            }
            /*************************************/
            CartShopping.Cart.Add(id,1);
            var response = new
            {
                CartShopping.Cart.Count,
                CartShopping.Cart.Amount
            };
            var model = db.M1Product.Find(id);//LẤY SẢN PHẨM KHÁCH ĐANG CHỌN
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult muanhanh(String TenNguoiNhan, String SoDTLienLac, String DiaChiGuiHang, String Email, String Ghichu, int soluong,int id)
        {
            //TẠO THÔNG TIN KHÁCH HÀNG LƯU VÀO TABLE ORDERSHOPING
            var sanpham = db.M1Product.Find(id);//LẤY SẢN PHẨM KHÁCH ĐANG CHỌN
            try
            {
                var os = new M1Custumers
                {
                   GroupID = 1, //Khách vảng lai  
                   Name = TenNguoiNhan,
                   Phone = SoDTLienLac,
                   Address = DiaChiGuiHang,
                   Email = Email,
                };
                db.M1Custumers.Add(os);
                db.SaveChanges();
                //TẠO THÔNG TIN ĐƠN HANG LUU VÀO TABLE ORDER
                decimal? tongtien = sanpham.Price * sanpham.Quantity;
                var o = new M1Orders
                {
                    M1Custumers = os,
                    MaDonHang = DateTime.Now.ToString("yyyyMMddhmmss"),
                    CreatedDate = DateTime.Now,
                    RequireDate = DateTime.Now.AddDays(7),
                    ShipName = TenNguoiNhan,
                    ShipMobile = SoDTLienLac,
                    ShipAddress = DiaChiGuiHang,
                    Description = Ghichu,
                    Amount = tongtien,
                    Status = 1,

                };
                db.M1Orders.Add(o);
                db.SaveChanges();
                //THÊM CHỈ TIẾT CÁC MẶT HÀNG               
                var d = new M1OrderDetail
                {
                    ProductID = sanpham.ID,
                    Code = sanpham.Code,
                    Name = sanpham.NameWEB,
                    M1Orders = o,
                    UnitPrice = sanpham.Price,
                    Discount = sanpham.Discount,
                    Quantity = soluong,
                };
                db.M1OrderDetail.Add(d);
                db.SaveChanges();
                CartShopping.Cart.Clear();
                return RedirectToAction("Hoantat", "Order");

            }
            catch
            {
                return View(sanpham);
            }
        }
        public ActionResult Hoantat()
        {
            return View();
        }
    }
}