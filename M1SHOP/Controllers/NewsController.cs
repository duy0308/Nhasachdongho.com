using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace M1SHOP.Controllers
{
    public class NewsController : dbController
    {
        // GET: News
        public ActionResult Index()
        {
            var model = db.M1Content.Where(t=>t.Status ==true).OrderByDescending(m=>m.CreatedDate).ToList();
            return View(model);
        }
        public ActionResult Details(int id=0)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.M1Content.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        public ActionResult NewbyGroupID(int id=0)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.M1Content.Where(t => t.Status == true && t.CategoryID == id).OrderByDescending(m => m.CreatedDate).ToList();
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
            
        }

    }
}