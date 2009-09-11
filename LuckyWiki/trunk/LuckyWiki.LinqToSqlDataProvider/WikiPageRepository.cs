using System;
using System.Linq;
using LuckyWiki.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace LuckyWiki.Data.LinqToSqlDataProvider {
    public class WikiPageRepository : IWikiPageRepository {
        private LuckyWikiDataContext dataContext;

        internal WikiPageRepository(LuckyWikiDataContext dataContext) {
            this.dataContext = dataContext;
        }

        #region IWikiPageRepository Members

        public IEnumerable<IWikiPage> GetPages() {
            return dataContext.WikiPages.ToList().Cast<IWikiPage>();
        }

        public IWikiPage GetPage(string title) {
            return dataContext.WikiPages.SingleOrDefault(p => p.Title == title && p.WikiPageTypeId == (byte)WikiPageTypes.Page);
        }

        public IWikiPage GetPage(int id) {
            return dataContext.WikiPages.SingleOrDefault(p => p.Id == id && p.WikiPageTypeId == (byte)WikiPageTypes.Page);
        }

        public IWikiPage GetUserPage(string username) {
            return dataContext.WikiPages.SingleOrDefault(p => p.Title == username && p.WikiPageTypeId == (byte)WikiPageTypes.UserPage);
        }

        public IWikiPage GetUserPage(int id) {
            return dataContext.WikiPages.SingleOrDefault(p => p.Id == id && p.WikiPageTypeId == (byte)WikiPageTypes.UserPage);
        }

        public IWikiPage GetParentPage(string title) {
            return dataContext.WikiPages.SingleOrDefault(p => p.Title == title).Parent;
        }

        public IWikiPage GetParentPage(int id) {
            return dataContext.WikiPages.SingleOrDefault(p => p.Id == id).Parent;
        }

        public IQueryable<IWikiPage> GetChildPages(string title) {
            return dataContext.WikiPages.SingleOrDefault(p => p.Title == title).Children.AsQueryable().Cast<IWikiPage>();
        }

        public IQueryable<IWikiPage> GetChildPages(int id) {
            return dataContext.WikiPages.SingleOrDefault(p => p.Id == id).Children.AsQueryable().Cast<IWikiPage>();
        }

        public IQueryable<IWikiPage> GetPagesByUser(string username) {
            IQueryable<IWikiPage> creatingPages = dataContext.WikiPages.Where(p => p.CreatingUser.Username == username).Cast<IWikiPage>();
            IQueryable<IWikiPage> modifyingPages = dataContext.WikiPages.Where(p => p.ModifyingUser.Username == username).Cast<IWikiPage>();
            return creatingPages.Concat(modifyingPages);
        }

        public IWikiPage CreatePage() {
            return new WikiPage();
        }

        public void Add(IWikiPage page) {
            if (string.IsNullOrEmpty(page.Title)) {
                throw new ArgumentNullException("page.Title");
            }

            dataContext.WikiPages.InsertOnSubmit((WikiPage)page);
        }

        public void Remove(IWikiPage page) {
            dataContext.WikiPages.DeleteOnSubmit((WikiPage)page);
        }

        public void Save() {
            dataContext.SubmitChanges(ConflictMode.FailOnFirstConflict);
        }

        #endregion
    }
}
