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
    public class ProductController : Controller
    {
        private ProductDAO _daoProduct = new ProductDAO();
        private ProductPhotoDAO _daoProductPhoto = new ProductPhotoDAO();


        #region Get Method
        // GET: Product

        public ActionResult Index(int page = 1)
        {
            try
            {
                var model = _daoProduct.GetAllProduct(page);
                return View(model);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                M1Product model = _daoProduct.GetProductDetail((int)id);

                if (model == null) // Không tồn tại sản phẩm có mã id
                {
                    return HttpNotFound();
                }
                else
                {
                    //Thông tin chung của view
                    ViewBag.Title = model.NameWEB;
                    ViewBag.Metatitle = model.MetaTitle;
                    ViewBag.Metadescription = model.MetaDescriptions;
                    ViewBag.Metaimage = Request.Url.Host + model.Image;

                    // Dữ liệu gửi ra View
                    ViewData["lstProductPhoto"] = _daoProductPhoto.GetPhotoByID(model.ID);
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult ListNew(int page = 1)
        {
            try
            {
                // Lấy dữ liệu gửi ra view
                var model = _daoProduct.GetLstNewProduct(page);
                return View(model);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult ProductListView(int id = 0, int page = 1)
        {
            try
            {
                ViewBag.idMHL = id;
                if (id > 0)
                {
                    int pageSize = 6;
                    var model = _daoProduct.GetProductByGroupID(id, page, pageSize);
                    return View(model);
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            catch(Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        #endregion


        #region Post Method

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


        #endregion


        /*************** Không tìm thấy View ***************/


        //public ActionResult List(int PageSize = 6)
        //{
        //    var Rowcount = db.M1Product.Count();
        //    ViewBag.PageCount = Math.Ceiling(1.0 * Rowcount / PageSize);
        //    return View("List");
        //}

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