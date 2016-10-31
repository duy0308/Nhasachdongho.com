namespace M1SHOP
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Improve SEO by stopping duplicate URL's due to case differences or trailing slashes.
            // See http://googlewebmastercentral.blogspot.co.uk/2010/04/to-slash-or-not-to-slash.html
            routes.AppendTrailingSlash = true;
            routes.LowercaseUrls = true;

            // IgnoreRoute - Tell the routing system to ignore certain routes for better performance.
            // Ignore .axd files.
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // Ignore everything in the Content folder.
            routes.IgnoreRoute("Content/{*pathInfo}");
            // Ignore everything in the Scripts folder.
            routes.IgnoreRoute("Scripts/{*pathInfo}");
            // Ignore the Forbidden.html file.
            routes.IgnoreRoute("Error/Forbidden.html");
            // Ignore the GatewayTimeout.html file.
            routes.IgnoreRoute("Error/GatewayTimeout.html");
            // Ignore the ServiceUnavailable.html file.
            routes.IgnoreRoute("Error/ServiceUnavailable.html");
            // Ignore the humans.txt file.
            routes.IgnoreRoute("humans.txt");

            // Enable attribute routing.
            routes.MapMvcAttributeRoutes();

            // Normal routes are not required because we are using attribute routing. So we don't need this MapRoute 
            // statement. Unfortunately, Elmah.MVC has a bug in which some 404 and 500 errors are not logged without 
            // this route in place. So we include this but look out on these pages for a fix:
            // https://github.com/alexbeletsky/elmah-mvc/issues/60
            // https://github.com/RehanSaeed/ASP.NET-MVC-Boilerplate/issues/8
            /** MAP ROUTE TIN TỨC **/
            routes.MapRoute(
                "Tinchitiet",
                "noi-dung/{SeoTitle}-{id}",
                new { controller = "News", action = "Details", id = UrlParameter.Optional },
                namespaces: new[] { "M1SHOP.Controllers" }
            );
            routes.MapRoute(
                "Tintheonhom",
                "thong-tin/{SeoTitle}-{id}/{Page}",
                new { controller = "News", action = "NewbyGroupID", id = UrlParameter.Optional, Page = UrlParameter.Optional },
                namespaces: new[] { "M1SHOP.Controllers" }
            );
            /** MAP ROUTE SẢN PHẨM **/
            routes.MapRoute(
                "Sanphamchitiet",
                "san-pham/{SeoTitle}-{id}",
                new { controller = "Product", action = "Details", id = UrlParameter.Optional },
                namespaces: new[] { "M1SHOP.Controllers" }
            );
            routes.MapRoute(
                "SanphamListView",
                "loai-mat-hang/{SeoTitle}-{id}/{Page}",
                new { controller = "Product", action = "ProductListView", id = UrlParameter.Optional , Page = UrlParameter.Optional},
                namespaces: new[] { "M1SHOP.Controllers" }
            );
            routes.MapRoute(
                "san-pham-moi",
                "san-pham-moi/{Page}",
                new { controller = "Product", action = "ListNew", id = UrlParameter.Optional , Page = UrlParameter.Optional },
                namespaces: new[] { "M1SHOP.Controllers" }
            );
            /******************************************************************/
            routes.MapRoute(
               "Lienhe",
               "lien-he",
               new { controller = "Home", action = "Contact", id = UrlParameter.Optional },
               namespaces: new[] { "M1SHOP.Controllers" }
            );
            routes.MapRoute(
               "Gioithieu",
               "gioi-thieu",
               new { controller = "Home", action = "About", id = UrlParameter.Optional },
               namespaces: new[] { "M1SHOP.Controllers" }
            );
            /******************************************************************/
            routes.MapRoute(
               name: "PagedList",
               url: "{controller}/{action}/{id}/{Page}",
               defaults: new { controller = "Home", action = "Index", Page = UrlParameter.Optional, id = UrlParameter.Optional },
               namespaces: new[] { "Nhasachdongho.Controllers" }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "M1SHOP.Controllers" });

        }
    }
}
