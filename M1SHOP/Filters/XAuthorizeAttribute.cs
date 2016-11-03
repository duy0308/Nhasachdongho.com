using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public class XAuthorizeAttribute: ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if (HttpContext.Current.Session["User"] == null)
        {
            HttpContext.Current.Session["ReturnUrl"] = HttpContext.Current.Request.Url.AbsoluteUri;
            HttpContext.Current.Response.Redirect("/Account/Login");
        }
    }
}