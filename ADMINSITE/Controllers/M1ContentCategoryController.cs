using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.EF;

namespace ADMINSITE.Controllers
{
    [XAdmin]
    public class M1ContentCategoryController : Controller
    {
        private DataContextModel db = new DataContextModel();

        // GET: M1ContentCategory
        public ActionResult Index()
        {
            return View(db.M1ContentCategory.OrderBy(x => x.ParentID).ToList());
        }

        // GET: M1ContentCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M1ContentCategory m1ContentCategory = db.M1ContentCategory.Find(id);
            if (m1ContentCategory == null)
            {
                return HttpNotFound();
            }
            return View(m1ContentCategory);
        }

        // GET: M1ContentCategory/Create
        public ActionResult Create()
        {
            ViewBag.Categories = db.M1ContentCategory.Where(x=>x.ParentID == 0).OrderBy(x=>x.DisplayOrder).ToList();

            return View();
        }

        // POST: M1ContentCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Photo,MetaTitle,ParentID,DisplayOrder,SeoTitle,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescriptions,Status,ShowOnHome,Language")] M1ContentCategory m1ContentCategory)
        {
            //LẤY ID MỚI NHẤT ĐỂ TẠO ID TIẾP THEO
            var cate = db.M1ContentCategory.OrderByDescending(x => x.ID).ToList().Take(1);
            int id_moi = 1;
            if (cate != null)
            {
                foreach(var item in cate)
                {
                    id_moi = item.ID + 1;
                }
            }
            //**************************************//
            if (ModelState.IsValid)
            {
                m1ContentCategory.ID = id_moi; 
                //************************************
                var ParentID_Cha = m1ContentCategory.ParentID; //Lấy ID của Nhóm cha truyền vào từ DropdownList
                //////////////////////////////////////////
                if (ParentID_Cha == null)
                    m1ContentCategory.ParentID = 0;
                else m1ContentCategory.ParentID = ParentID_Cha;
                //Nếu chọn chính mình thì là Menu chính
                var id_Menu_cha = m1ContentCategory.ID;
                if (id_Menu_cha == ParentID_Cha)
                    m1ContentCategory.ParentID = 0;
                //*********************************************
                string uAdmin = Session["User"].ToString();
                m1ContentCategory.ModifiedBy = uAdmin;
                m1ContentCategory.ModifiedDate = DateTime.Now;
                m1ContentCategory.CreatedBy = uAdmin;
                m1ContentCategory.CreatedDate = DateTime.Now;

                db.M1ContentCategory.Add(m1ContentCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(m1ContentCategory);
        }

        // GET: M1ContentCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M1ContentCategory m1ContentCategory = db.M1ContentCategory.Find(id);
            if (m1ContentCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.M1ContentCategory.Where(x => x.ParentID == 0).OrderBy(x => x.DisplayOrder).ToList();
            return View(m1ContentCategory);
        }

        // POST: M1ContentCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Photo,MetaTitle,ParentID,DisplayOrder,SeoTitle,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescriptions,Status,ShowOnHome,Language")] M1ContentCategory m1ContentCategory)
        {
            
            if (ModelState.IsValid)
            {
                string uAdmin = Session["User"].ToString();
                m1ContentCategory.ModifiedBy = uAdmin;
                m1ContentCategory.ModifiedDate = DateTime.Now;
                //************************************
                var ParentID_Cha = m1ContentCategory.ParentID; //Lấy ID của Nhóm cha truyền vào từ DropdownList
                //////////////////////////////////////////
                if (ParentID_Cha == null)
                    m1ContentCategory.ParentID = 0;
                else m1ContentCategory.ParentID = ParentID_Cha;

                //Nếu chọn chính mình thì là Menu chính
                var id_Menu_cha = m1ContentCategory.ID;
                if (id_Menu_cha == ParentID_Cha)
                    m1ContentCategory.ParentID = 0;
                
                //*********************************************

                db.Entry(m1ContentCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(m1ContentCategory);
        }

        // GET: M1ContentCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M1ContentCategory m1ContentCategory = db.M1ContentCategory.Find(id);
            if (m1ContentCategory == null)
            {
                return HttpNotFound();
            }
            return View(m1ContentCategory);
        }

        // POST: M1ContentCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            M1ContentCategory m1ContentCategory = db.M1ContentCategory.Find(id);
            db.M1ContentCategory.Remove(m1ContentCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
