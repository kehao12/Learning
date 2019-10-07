using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Learning.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
        name: "Student",
        url: "student/{id}/{name}/{standardId}",
        defaults: new { controller = "Student", action = "Index", id = UrlParameter.Optional, name = UrlParameter.Optional, standardId = UrlParameter.Optional },
        constraints: new { id = @"\d+" }
    );



            routes.MapRoute(
         name: "Login",
         url: "dang-nhap",
         defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
          namespaces: new string[] { "Learning.Web.Controllers" }
     );
            routes.MapRoute(
           name: "About",
           url: "gioi-thieu",
           defaults: new { controller = "About", action = "Index" },
           namespaces: new string[] { "Learning.Web.Controllers" }
       );
            routes.MapRoute(
             name: "Course Category",
             url: "{alias}-cc-{id}",
             defaults: new { controller = "Course", action = "Category", id = UrlParameter.Optional , alias = UrlParameter.Optional },
               namespaces: new string[] { "Learning.Web.Controllers" }
         );

            routes.MapRoute(
             name: "Course",
             url: "{alias}-c-{courseId}",
             defaults: new { controller = "Course", action = "Detail", productId = UrlParameter.Optional },
               namespaces: new string[] { "Learning.Web.Controllers" }
         );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                  namespaces: new string[] { "Learning.Web.Controllers" }
            );
        }
    }
}
