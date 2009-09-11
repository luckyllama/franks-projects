using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using LuckyWiki.Mvc;
using LuckyWiki.Data;

namespace LuckyWiki.Web.Controllers {
    public class UserPageController : LuckyWikiBaseController {
        
        public UserPageController() : base() { }

        // only for unit testing
        public UserPageController(IWikiPageRepository wikiPageRepository) {
            this.WikiPageRepository = wikiPageRepository;
        }

        public ActionResult Index(string title) {
            return RedirectToAction("Display", new { title = title });
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Display(string title) {
            IWikiPage page = WikiPageRepository.GetUserPage(title);
            if (page != null) {
                return View(page);
            } else {
                if (MembershipRepository.ContainsUser(title)) {
                    return RedirectToAction("Create", new { title = title });
                } else {
                    ViewData["QueriedUser"] = title;
                    return View("NoUserFound");
                }
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create(string title) {
            IWikiPage page = WikiPageRepository.CreatePage();
            page.Title = title;
            page.WikiPageType = WikiPageTypes.UserPage;
            return View(page);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(string title, FormCollection values) {
            IWikiPage page = WikiPageRepository.CreatePage();

            page.Title = title;
            page.CreatingUser = User;
            page.Created = DateTime.Now;
            page.WikiPageType = WikiPageTypes.UserPage;

            UpdateModel(page);

            WikiPageRepository.Add(page);
            WikiPageRepository.Save();

            return RedirectToAction("Display", new { title = title });
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
