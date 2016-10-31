using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using PagedList;
using M1SHOP.Models;
using Models.EF;
using System.Collections.Generic;
using Models.DAO;

namespace M1SHOP.Controllers
{
    public class ProductController : dbController
    {
        // GET: Product
        public ActionResult Index(int page=1)
        {
            int pageSize = 30;
            int pageNumber = page;
            var model = db.M1Product.OrderByDescending(p => p.ModifiedDate).ToList();
            return View(model.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = db.M1Product.Find(id);
            
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        public ActionResult ListNew(int? page)
        {
            int pageSize = 30;
            int pageNumber = (page ?? 1);
            var model = db.M1Product.Where(m => m.Status == true && m.Showhome == true).OrderByDescending(p => p.CreatedDate).Take(120).ToList();
            return View(model.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult ProductListView(int id=0, int page = 1)
        {
            ViewBag.idMHL = id;
            var model = new List<M1Product>();
            if (id != null && id > 0)
            {
                var sanpham = new ProductGetDAO();
                model = sanpham.GetByGroupID(id);
            }
            int pageSize = 20;
            int pageNumber = page;// (page ?? 1);
            /****************************/
            ViewBag.pageCount = (int)Math.Ceiling(1.0 * model.Count / pageSize);
            /*********************************/
            return View(model.ToPagedList(pageNumber, pageSize));
            
        }
        [HttpPost]
        public ActionResult Details(M1Product model)
        {
            int number = int.Parse(Request["soluong"]);
            CartShopping.Cart.Add(model.ID, number);
            var response = new
            {
                CartShopping.Cart.Count,
                CartShopping.Cart.Amount
            };
            return RedirectToAction("Index", "Cart");
        }
        public ActionResult List(int PageSize = 6)
        {
            var Rowcount = db.M1Product.Count();
            ViewBag.PageCount = Math.Ceiling(1.0 * Rowcount / PageSize);
            return View("List");
        }
        //public ActionResult LoadPage(int PageNo = 0, int PageSize = 6)
        //{
        //    var model = db.M1Product.OrderBy(p => p.CREATED).Skip(PageNo * PageSize).Take(PageSize);
        //    //Thread.Sleep(2000); //Deplay de test load site
        //    return PartialView(model);
        //}
        //public ActionResult LoadPage(int PageNo = 0, int PageSize = 3)
        //{
        //var model = db.M1Product.OrderByDescending(m => m.CREATED)
        //    .Skip(PageNo * PageSize)
        //    .Take(PageSize)
        //    .ToList();

        //    return PartialView(model);
        //}
        //public ActionResult List(int Id = 0, int PageNo = 0, int PageSize = 3)
        //{
        //    ViewBag.PageCount = getPageCount();
        //    var model = db.M1Product.Where((m => m.CategoryID == Id)).OrderByDescending(m => m.ModifiedDate)
        //        .Skip(PageNo * PageSize)
        //        .Take(PageSize)
        //        .ToList();
        //    return PartialView("_GridView", model);
        //}
        //public int getPageCount(int Id=0,int PageSize = 10)
        //{
        //    var rowCount = db.M1Product.Where((m => m.CategoryID == Id)).Count();
        //    return (int)Math.Ceiling(1.0 * rowCount / PageSize);
        //}

        
    }
}