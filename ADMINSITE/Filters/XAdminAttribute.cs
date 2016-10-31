using Models.EF;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public class XAdminAttribute: ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var Master = HttpContext.Current.Session["Master"] as M1Masters;

        // Authentication
        if (Master == null)
        {
            HttpContext.Current.Response.Redirect("/Account/Login");
        }

        // Authorization
        //var Action = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName
        //    + "/" + filterContext.ActionDescriptor.ActionName;
        //Action = Action.ToLower();

        //DataContextModel db = new DataContextModel();
        //if (db.M1WebActions.Where(a => a.Name == Action).Count() > 0)
        //{
        //    var RoleIds = db.M1MasterRoles
        //        .Where(mr => mr.MasterId == Master.UserName)
        //        .Select(mr => mr.RoleId)
        //        .ToList();
        //    var Count = db.M1RoleActions
        //        .Where(ra => ra.M1WebActions.Name == Action &&
        //            RoleIds.Contains(ra.RoleId)).Count();
        //    if (Count == 0)
        //    {
        //        HttpContext.Current.Session["ReturnUrl2"] = HttpContext.Current.Request.Url.AbsoluteUri;
        //        HttpContext.Current.Response.Redirect("/Admin/Home/Login");
        //    }
        //}
    }
}