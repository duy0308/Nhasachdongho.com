using DevExpress.Web.Mvc;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADMINSITE.Controllers
{
    [XAdmin]
    public class OrderController : dbController
    {
        // GET: Order
        public ActionResult Index()
        {
            var model = db.M1Orders.OrderByDescending(m => m.CreatedDate).ToList();
            return View(model);
        }
        [ValidateInput(false)]
        public ActionResult OrderDetails(int id = 0)
        {
            var model = db.M1OrderDetail.Where(m => m.ID == id).OrderBy(m => m.ID).ToList();
            return View(model);
        }
        public ActionResult OrderUpdate(int id = 0)
        {
            var model = db.M1Orders.Find(id);
            return View("OrderUpdate", model);
        }
        [HttpPost]
        public ActionResult OrderUpdate(int Trangthai, int id = 0)
        {
            var model = db.M1Orders.Find(id);
            if (ModelState.IsValid)
            {
                model.Status = Trangthai;
                /************************************/
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        public ActionResult Custumer()
        {
            var model = db.M1Custumers.OrderByDescending(m => m.CreatedDate).ToList();
            return View(model);
        }


        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = db.M1Custumers.OrderByDescending(m => m.CreatedDate).ToList();
            return PartialView("_GridViewPartial", model);
        }

         
    }

}