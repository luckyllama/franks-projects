using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using LuckyWiki.Data;
using LuckyWiki.Configuration;
using LuckyWiki.Mvc;

namespace LuckyWiki.Web.Controllers {
    public class PageController : LuckyWikiBaseController {
        //
        // GET: /Page/

        public PageController() : base() { }

        // only for unit testing
        public PageController(IWikiPageRepository wikiPageRepository) {
            this.WikiPageRepository = wikiPageRepository;
        }

        public ActionResult Index(string title) {
            return RedirectToAction("Display", new { title = title });
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Display(string title) {
            IWikiPage page = WikiPageRepository.GetPage(title);
            if (page != null) {
                return View(page);
            } else {
                return RedirectToAction("Create", new { title = title });
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create(string title) {
            IWikiPage page = WikiPageRepository.CreatePage();
            page.Title = title;
            page.WikiPageType = WikiPageTypes.Page;
            return View(page);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(string title, FormCollection values) {
            IWikiPage page = WikiPageRepository.CreatePage();

            page.CreatingUser = User;
            page.Created = DateTime.Now;
            page.WikiPageType = WikiPageTypes.Page;

            UpdateModel(page);

            WikiPageRepository.Add(page);
            WikiPageRepository.Save();

            return RedirectToAction("Display", new { title = title });
            //return RedirectToAction("Display", new { title = page.Title });
        }
        
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(string title) {
            IWikiPage page = WikiPageRepository.GetPage(title);
            return View(page);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(string title, FormCollection values) {
            IWikiPage page = WikiPageRepository.GetPage(title);

            page.ModifyingUser = User;
            page.Modified = DateTime.Now;

            UpdateModel(page);

            WikiPageRepository.Save();

            return RedirectToAction("Display", new { title = page.Title });
        }

    }
}
