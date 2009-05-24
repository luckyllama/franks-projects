using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using IkariamTools.LinqToSql;
using IkariamTools.Data.Models;

namespace IkariamTools.Web.Controllers {
    public class CityController : Controller {
        //
        // GET: /City/

        public ActionResult Index() {
            return List();
        }

        public ActionResult List() {
            CityRepository cityRepository = new CityRepository();
            List<ICity> cities = cityRepository.GetCities().ToList<ICity>();
            return View("List", cities);
        }

        //
        // GET: /City/Details/5

        public ActionResult Details(int id) {
            return View();
        }

        //
        // GET: /City/Create

        public ActionResult Create() {
            return View();
        }

        //
        // POST: /City/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection) {
            try {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        //
        // GET: /City/Edit/5

        public ActionResult Edit(int id) {
            return View();
        }

        //
        // POST: /City/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
