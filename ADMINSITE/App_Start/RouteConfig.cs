using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ADMINSITE {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.ashx/{*pathInfo}");

            routes.MapRoute(
               "MathangEdit",
               "Product/Edit/{id}",
               new { controller = "Product", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               "MathangShow",
               "Product/{show}/{id}",
               new { controller = "Product", action = "Index",  id = UrlParameter.Optional, show = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //   "Mathang2",
            //   "Product/{show}",
            //   new { controller = "Product", action = "Index", show = UrlParameter.Optional }
            //);

            routes.MapRoute(
               "Nhommathang",
               "ProductCategory/{kieu}",
               new { controller = "ProductCategory", action = "Index", kieu = UrlParameter.Optional}
           );

            routes.MapRoute(
                name: "Default", // Route name
                url: "{controller}/{action}/{id}", // URL with parameters
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }
    }
}