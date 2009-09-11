using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LuckyWiki.Web {

    public class MvcApplication : System.Web.HttpApplication {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "PageActions",
                "Page/{action}/{title}",
                new { controller = "Page", action = "Index", title = "Homepage" }
            );

            routes.MapRoute(
                "PageDefault",
                "Page/{title}",
                new { controller = "Page", action = "Display", title = "Homepage" }
            );

            routes.MapRoute(
                "UserPageDefault",
                "UserPage/{action}/{title}",
                new { controller = "UserPage", action = "Display", title = "" }
            );

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Page", action = "Index", id = "" }  // Parameter defaults
            );

        }

        protected void Application_Start() {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}