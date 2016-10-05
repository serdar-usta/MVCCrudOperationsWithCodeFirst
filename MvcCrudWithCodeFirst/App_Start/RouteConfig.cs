using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcCrudWithCodeFirst
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Product",
                url: "urunler/{*path}",
                defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Category",
                url: "kategoriler/ozel-kategoriler/{*path}",
                defaults: new { controller = "Categories", action = "Index", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Search",
                url: "ara/{*path}",
                defaults: new { controller = "search", action = "Index", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "CatchAll",
                url: "sirketimiz/hakkimizda",
                defaults: new { controller = "Company", action = "About", id = UrlParameter.Optional }
                );
        }
    }
}
