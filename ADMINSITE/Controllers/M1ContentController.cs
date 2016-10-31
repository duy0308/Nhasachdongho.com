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
    
    public class M1ContentController : Controller
    {
        private DataContextModel db = new DataContextModel();
       
        // GET: M1Content
        public ActionResult Index()
        {
            var m1Content = db.M1Content.Include(m => m.M1ContentCategory);
            return View(m1Content.ToList());
        }

        // GET: M1Content/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M1Content m1Content = db.M1Content.Find(id);
            if (m1Content == null)
            {
                return HttpNotFound();
            }
            return View(m1Content);
        }

        // GET: M1Content/Create
        [ValidateInput(false)]
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.M1ContentCategory.Where(x=>x.ParentID > 0), "ID", "Name");
            return View();
        }

        // POST: M1Content/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Name,SeoTitle,MetaTitle,Description,Image,CategoryID,Detail,Warranty,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescriptions,Status,TopHot,Is_Stick,Is_special,ViewCount,Tags,Language")] M1Content m1Content)
        {
            string uAdmin = Session["User"].ToString();

            if (ModelState.IsValid)
            {
                m1Content.CreatedBy = uAdmin;
                m1Content.CreatedDate = DateTime.Now;
                m1Content.ModifiedBy = uAdmin;
                m1Content.ModifiedDate = DateTime.Now;
                m1Content.ViewCount = 0;
                db.M1Content.Add(m1Content);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.M1ContentCategory.Where(x=>x.ParentID > 0), "ID", "Name", m1Content.CategoryID);
            return View(m1Content);
        }

        // GET: M1Content/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M1Content m1Content = db.M1Content.Find(id);
            if (m1Content == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.M1ContentCategory.Where(x => x.ParentID > 0), "ID", "Name", m1Content.CategoryID);
            return View(m1Content);
        }

        // POST: M1Content/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,Name,SeoTitle,MetaTitle,Description,Image,CategoryID,Detail,Warranty,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescriptions,Status,TopHot,Is_Stick,Is_special,ViewCount,Tags,Language")] M1Content m1Content)
        {
            if (ModelState.IsValid)
            {
                string uAdmin = Session["User"].ToString();
                m1Content.ModifiedBy = uAdmin;
                m1Content.ModifiedDate = DateTime.Now;
                db.Entry(m1Content).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.M1ContentCategory.Where(x => x.ParentID > 0), "ID", "Name", m1Content.CategoryID);
            return View(m1Content);
        }

        // GET: M1Content/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M1Content m1Content = db.M1Content.Find(id);
            if (m1Content == null)
            {
                return HttpNotFound();
            }
            return View(m1Content);
        }

        // POST: M1Content/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            M1Content m1Content = db.M1Content.Find(id);
            db.M1Content.Remove(m1Content);
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
