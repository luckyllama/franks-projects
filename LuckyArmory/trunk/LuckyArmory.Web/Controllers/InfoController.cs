using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuckyArmory.Lib.Handlers;

namespace LuckyArmory.Web.Controllers {

    public class InfoController : Controller {

        public ActionResult General(string realm, string name, string favorite) {
            ViewData["Title"] = "General Info";

            if (string.IsNullOrEmpty(realm) || string.IsNullOrEmpty(name)) {
                return RedirectToAction("Index", "Home");
            }

            if (favorite == "Save") {
                FavoritesHandler.SaveNewFavorite(realm, name);
            }

            ViewData["Realm"] = realm;
            ViewData["Name"] = name;

            return View();
        }

    }
}
