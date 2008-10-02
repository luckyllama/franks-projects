using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Configuration;

namespace LuckyArmory.Web {

    public class GlobalApplication : System.Web.HttpApplication {

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "ItemInfo",
                "Info/Item/{id}",
                new { controller = "Info", action = "Item", id = "-1" }
            );

            routes.MapRoute(
                "DefaultWithInfo", 
                "{controller}/{action}/{realm}/{name}",
                new {  }  
            );

            routes.MapRoute(
                "Default",
                "{controller}/{action}",
                new { controller = "Home", action = "Index", id = "" }
            );
        }

        protected void Application_Start() {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}