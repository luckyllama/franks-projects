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
            int iisVersion = Convert.ToInt32(ConfigurationManager.AppSettings["IISVersion"], System.Globalization.CultureInfo.InvariantCulture);
            string appendedController = "";

            if (iisVersion < 7) {
                appendedController = ".mvc";
            }

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "GeneralInfo",
                "Info" + appendedController + "/General/{realm}/{name}/{favorite}",
                new { controller = "Info", action = "General", realm = "realm", name = "name", favorite = "" }
                );
            routes.MapRoute(
                "GearInfo",
                "Info" + appendedController + "/Gear/{realm}/{name}",
                new { controller = "Info", action = "Gear", realm = "realm", name = "name" }
                );
            routes.MapRoute(
                "ItemInfo",
                "Info" + appendedController + "/Item/{id}",
                new { controller = "Info", action = "Item", id = "-1" }
                );

            routes.Add(new Route("{controler}" + appendedController + "/{action}",
                new RouteValueDictionary (new { controller = "Home", action = "Index" }),
                new MvcRouteHandler()));

        }

        protected void Application_Start() {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}