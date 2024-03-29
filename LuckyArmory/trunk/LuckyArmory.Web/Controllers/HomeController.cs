﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using LuckyArmory.Lib.Handlers;

namespace LuckyArmory.Web.Controllers {

    public class HomeController : Controller {

        #region Index

        public ActionResult Index(string errorMessage) {
            ViewData["Title"] = "Home Page";
            ViewData["ErrorMessage"] = errorMessage.UrlDecode();

            //ViewData["Favorites"] = getFavoritesData(FavoritesHandler.GetFavorites());
            ViewData["Favorites"] = FavoritesHandler.GetFavorites();

            return View();
        }

        private Dictionary<string, string> getFavoritesData(IDictionary<string, string> favorites) {
            Dictionary<string, string> repeaterData = new Dictionary<string, string>();

            if (favorites.Count == 0) {
                repeaterData.Add("No Favorites", "");
            } else {
                foreach (string key in favorites.Keys) {
                    repeaterData.Add(rapTextInFavoritesLink(favorites[key], key), "<a href=\"#\" class=\"DeleteIcon\"></a>");
                }
            }

            return repeaterData;
        }

        private string rapTextInFavoritesLink(string queryString, string linkText) {
            return "<a href=\"GeneralInfo.aspx?" + queryString + "\">" + linkText + "</a>";
        }

        #endregion Index

        
        public ActionResult LookUp(string Realm, string Name, string favorite) {
            if (string.IsNullOrEmpty(Realm) || string.IsNullOrEmpty(Name)) {
                return RedirectToAction("Index", "Home", new { errorMessage = "Realm and Character Name are Required.".UrlEncode() });
            }

            return RedirectToAction("General", "Info", new { realm = Realm.UrlEncode(), name = Name.UrlEncode(), favorite = favorite });
        }

        public ActionResult Delete(string realm, string name) {
            if (string.IsNullOrEmpty(realm) || string.IsNullOrEmpty(name)) {
                return RedirectToAction("Index", "Home");
            }

            FavoritesHandler.DeleteFavorite(realm, name);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult About() {
            ViewData["Title"] = "About Page";

            return View();
        }

        public ActionResult Settings() {
            ViewData["Title"] = "Settings";

            return View();
        }

    }
}
