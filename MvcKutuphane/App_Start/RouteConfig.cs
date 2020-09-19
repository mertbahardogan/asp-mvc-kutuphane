using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcKutuphane
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

         //   routes.MapRoute(
         //        name: "Error",
         //        url: "error/{kod}",
         //        defaults: new { controller = "Error", action = "Page404", kod = UrlParameter.Optional } //burası global.asax yaptığımız yönlendirmenin adres şeması oldu bu üstte yer almalı
         //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

         
        }
    }
}
