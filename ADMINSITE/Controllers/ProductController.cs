using DevExpress.Web.Mvc;
using Models.DAO;
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
    public class ProductController : dbController
    {
        //XỬ LÝ MẶT HÀNG - SẢN PHẨM
        //Lấy các sản phẩm
        public ActionResult Index(string show="xem10", int id=0)
        {
            
            ViewBag.CategoryID = new SelectList(db.M1ProductCategory.Where(m => m.Level == 1).OrderBy(m => m.Path), "ID", "Name");
            List<M1Product> model = null;
            //if (id == 0)
            //{
            if (show == "xem10")
            {
                model = db.M1Product.OrderByDescending(m => m.CreatedDate).Take(10).ToList();
                return View(model);
            }
            else if (show == "xem50")
            {
                model = db.M1Product.OrderByDescending(m => m.CreatedDate).Take(50).ToList();
                return View(model);
            }
            else if (show == "xem100")
            {
                model = db.M1Product.OrderByDescending(m => m.CreatedDate).Take(100).ToList();
                return View(model);
            }
            else if (show == "cate")
            {
                var GetSanpham = new ProductGetDAO();
                model = GetSanpham.GetByGroupID(id);
                return View(model);
            }
            else if (show == "all")
            {
                model = db.M1Product.OrderByDescending(m => m.CreatedDate).ToList();
            }

            //}
            //else
            //{
            //    model = db.M1Product.Where(x=>x.CategoryID==id).OrderByDescending(m => m.CreatedDate).ToList();
            //}
            model = db.M1Product.OrderByDescending(m => m.CreatedDate).Take(10).ToList();
            return View(model);
            
            
        }

        //Lấy một sản phẩm ra sửa
        public ActionResult Edit(int? id)
        {
            var m1Product = db.M1Product.Find(id);
            if (m1Product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.M1ProductCategory, "ID", "Name", m1Product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.M1Suppliers, "Id", "Name", m1Product.SupplierID);
            return View(m1Product);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,Name,NameWEB,Code,SeoTitle,MetaTitle,Description,Image,Price,PromotionPrice,Discount,IncludedVAT,Quantity,CategoryID,CategoryIDS,SupplierID,Detail,Warranty,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescriptions,Status,Is_Stick,Is_special,Showhome,TopHot,ViewCount,Tags")] M1Product m1Product, int id)
        {

            string Username = "";
            if (ModelState.IsValid)
            {
                m1Product.ID = id;     
                m1Product.ModifiedDate = DateTime.Now;
                m1Product.ModifiedBy = Username;
                db.Entry(m1Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.M1ProductCategory, "ID", "Name", m1Product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.M1Suppliers, "Id", "Name", m1Product.SupplierID);
            return View(m1Product);
        }
        //XỬ LÝ LOẠI MẶT HÀNG
        #region
        public ActionResult Loaimathang()
        {
            var LoaiSPLv1 = db.M1ProductCategory.Where(m => m.Level == 1).OrderBy(m => m.Path).ToList();
            return View(LoaiSPLv1);
        }
        /***************************************************************/
        //CẬT NHẬT LOẠI SẢN PHẨM
        public ActionResult MathangloaiEdit(int id=0)
        {
            M1ProductCategory mATHANGLOAI = db.M1ProductCategory.Find(id);
            if (mATHANGLOAI == null)
            {
                return HttpNotFound();
            }
            return View(mATHANGLOAI);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MathangloaiEdit(M1ProductCategory model)
        {
            var Master = Session["Master"] as M1Masters;
            /******************************************/
            if (ModelState.IsValid)
            {
                model.ModifiedDate = DateTime.Now;
                //model.ModifiedBy = Master.UserName;
                /************************************/
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Loaimathang");
            }
            return View(model);
        }

        #endregion
        
        public ActionResult Nhacungcap()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial(string hienthi= "xem50")
        {
            var GetSanpham = new ProductGetDAO();
            //XET KIỂU HIỂN THỊ
            List<M1Product> model = new List<M1Product>();
            if (hienthi == "all")
            {
                model = db.M1Product.OrderByDescending(m => m.CreatedDate).ToList();
            }
            else if (hienthi == "xem50")
            {
                model = db.M1Product.OrderByDescending(m => m.CreatedDate).Take(50).ToList();
            }
           
            return PartialView("_GridViewPartial", model);

        }
        public ActionResult GridViewPartial2(int id = 0)
        {
            var GetSanpham = new ProductGetDAO();
            //XET KIỂU HIỂN THỊ
            List<M1Product> model = new List<M1Product>();
            if (id == 0 || id == null)
            {
                model = db.M1Product.OrderByDescending(m => m.CreatedDate).ToList();
            }
            else
            {
                model = GetSanpham.GetByGroupID(id).OrderByDescending(m => m.CreatedDate).ToList();

            }
            return PartialView("_GridViewPartial2.cshtml", model);

        }
    }
}