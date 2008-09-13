using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LuckyArmory.Web {

    public class GlobalApplication : System.Web.HttpApplication {

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Info",
                "Info/General/{realm}/{name}/{favorite}",
                new { controller = "Info", action = "General", realm = "realm", name = "name", favorite = "" }
                );

            routes.Add(new Route("{controler}/{action}",
                new RouteValueDictionary (new { controller = "Home", action = "Index" }),
                new MvcRouteHandler()));

        }

        protected void Application_Start() {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}