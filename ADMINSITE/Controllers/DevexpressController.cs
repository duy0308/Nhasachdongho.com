using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADMINSITE.Controllers
{
    public class DevexpressController : dbController
    {
        // GET: Devexpress
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult HtmlEditor3Partial()
        {
            var model = db.M1Footer.Find(1);
            return PartialView("~/Views/Home/_HtmlEditor3Partial.cshtml", model);
        }
    }




}