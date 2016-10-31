using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.EF;

namespace ADMINSITE.Controllers
{
    public class ProductCategoryController : Controller
    {
        private DataContextModel db = new DataContextModel();

        // GET: ProductCategory
        public async Task<ActionResult> Index(string kieu)
        {
            List<M1ProductCategory> model = null;
            if(kieu == "lv1")
            {
                model = await db.M1ProductCategory.Where(x => x.Level == 1).OrderBy(x => x.Level).ToListAsync();
            }
            else if (kieu == "lv2")
            {
                model = await db.M1ProductCategory.Where(x => x.Level == 2).OrderBy(x => x.Level).ToListAsync();
            }
            else if(kieu == "lv3")
            {
                model = await db.M1ProductCategory.Where(x => x.Level == 3).OrderBy(x => x.Level).ToListAsync();
            }
            else if(kieu == "lv4")
            {
                model = await db.M1ProductCategory.Where(x => x.Level == 4 ).OrderBy(x => x.Level).ToListAsync();
            }
            else if(kieu == "lv5")
            {
                model = await db.M1ProductCategory.Where(x => x.Level == 5).OrderBy(x => x.Level).ToListAsync();
            }
            else if(kieu == "showhome")
            {
                model = await db.M1ProductCategory.Where(x => x.ShowOnHome == true).OrderBy(x => x.Level).ToListAsync();
            }
            else if(kieu == "noshowhome")
            {
                model = await db.M1ProductCategory.Where(x => x.ShowOnHome == false).OrderBy(x => x.Level).ToListAsync();
            }
            else if(kieu == "noshowhome")
            {
                model = await db.M1ProductCategory.Where(x => x.ShowOnHome == false).OrderBy(x => x.Level).ToListAsync();
            }
            else if(kieu == "active")
            {
                model = await db.M1ProductCategory.Where(x => x.Status == true).OrderBy(x => x.Level).ToListAsync();
            }
            else if(kieu == "noactive")
            {
                model = await db.M1ProductCategory.Where(x => x.ShowOnHome == false).OrderBy(x => x.Level).ToListAsync();
            }
            else 
            {
                model = await db.M1ProductCategory.Where(x => x.Level > 0).OrderBy(x => x.Level).ToListAsync();
            }
            return View(model);
        }

        // GET: ProductCategory/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M1ProductCategory m1ProductCategory = await db.M1ProductCategory.FindAsync(id);
            if (m1ProductCategory == null)
            {
                return HttpNotFound();
            }
            return View(m1ProductCategory);
        }

        // GET: ProductCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,NameWEB,Code,Image,MetaTitle,ParentID,Level,DisplayOrder,Descriptions,SeoTitle,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescriptions,Path,Status,ShowOnHome,Note,Tags")] M1ProductCategory m1ProductCategory)
        {
            if (ModelState.IsValid)
            {
                db.M1ProductCategory.Add(m1ProductCategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(m1ProductCategory);
        }

        // GET: ProductCategory/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M1ProductCategory m1ProductCategory = await db.M1ProductCategory.FindAsync(id);
            if (m1ProductCategory == null)
            {
                return HttpNotFound();
            }
            return View(m1ProductCategory);
        }

        // POST: ProductCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,NameWEB,Code,Image,MetaTitle,ParentID,Level,DisplayOrder,Descriptions,SeoTitle,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescriptions,Path,Status,ShowOnHome,Note,Tags")] M1ProductCategory m1ProductCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m1ProductCategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(m1ProductCategory);
        }

        // GET: ProductCategory/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M1ProductCategory m1ProductCategory = await db.M1ProductCategory.FindAsync(id);
            if (m1ProductCategory == null)
            {
                return HttpNotFound();
            }
            return View(m1ProductCategory);
        }

        // POST: ProductCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M1ProductCategory m1ProductCategory = await db.M1ProductCategory.FindAsync(id);
            db.M1ProductCategory.Remove(m1ProductCategory);
            await db.SaveChangesAsync();
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
