using M1SHOP.Controllers;
using M1SHOP.Models;
using Models.EF;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace M1SHOP.Controllers
{
    public class CartController : dbController
    {
        public async Task<ActionResult> AddSL(int? id)
        {
            if (id == null || id <= 0) return Redirect("/");

            M1Product mATHANG = await db.M1Product.FindAsync(id);
            if (mATHANG == null)
            {
                return HttpNotFound();
            }
            return View(mATHANG);
        }
        [HttpPost]
        public ActionResult AddSL(M1Product model)
        {
            int number = int.Parse(Request["soluong"]);
            CartShopping.Cart.Add(model.ID,number);
            var response = new
            {
                CartShopping.Cart.Count,
                CartShopping.Cart.Amount
            };
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int Id)
        {
            CartShopping.Cart.Remove(Id);
            var response = new
            {
                CartShopping.Cart.Count,
                CartShopping.Cart.Amount
            };
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Clear()
        {
            CartShopping.Cart.Clear();
            return View("Index");
        }

        public ActionResult Update()
        {
            foreach (var p in CartShopping.Cart.Items)
            {
                String name = p.ID.ToString();
                int newQty = int.Parse(Request[name]);
                CartShopping.Cart.Update(p.ID, newQty);
            }
            return View("Index");
        }
    }
}