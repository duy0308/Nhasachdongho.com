using System.Web.Mvc;
using Models;
using Models.EF;

namespace ADMINSITE.Controllers
{
    public class dbController : Controller
    {
        protected DataContextModel db = new DataContextModel();
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                db.Dispose();
            }
        }
    }
}