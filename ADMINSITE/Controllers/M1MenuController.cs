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
    public class M1MenuController : Controller
    {
        private DataContextModel db = new DataContextModel();

        // GET: M1Menu
        public ActionResult Index()
        {
            var m1Menu = db.M1Menu.Include(m => m.M1MenuType).OrderBy(x=>x.DisplayOrder);
            return View(m1Menu.ToList());
        }

        // GET: M1Menu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M1Menu m1Menu = db.M1Menu.Find(id);
            if (m1Menu == null)
            {
                return HttpNotFound();
            }
            return View(m1Menu);
        }

        // GET: M1Menu/Create
        public ActionResult Create()
        {
            ViewBag.TypeID = new SelectList(db.M1MenuType, "ID", "Name");
            return View();
        }

        // POST: M1Menu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Text,Link,DisplayOrder,Target,Status,TypeID")] M1Menu m1Menu)
        {
            if (ModelState.IsValid)
            {
                db.M1Menu.Add(m1Menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TypeID = new SelectList(db.M1MenuType, "ID", "Name", m1Menu.TypeID);
            return View(m1Menu);
        }

        // GET: M1Menu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M1Menu m1Menu = db.M1Menu.Find(id);
            if (m1Menu == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeID = new SelectList(db.M1MenuType, "ID", "Name", m1Menu.TypeID);
            return View(m1Menu);
        }

        // POST: M1Menu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Text,Link,DisplayOrder,Target,Status,TypeID")] M1Menu m1Menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m1Menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypeID = new SelectList(db.M1MenuType, "ID", "Name", m1Menu.TypeID);
            return View(m1Menu);
        }

        // GET: M1Menu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M1Menu m1Menu = db.M1Menu.Find(id);
            if (m1Menu == null)
            {
                return HttpNotFound();
            }
            return View(m1Menu);
        }

        // POST: M1Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            M1Menu m1Menu = db.M1Menu.Find(id);
            db.M1Menu.Remove(m1Menu);
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
