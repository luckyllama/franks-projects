using System.Linq;
using System.Collections.Generic;

namespace LuckyWiki.Data {
    public interface IWikiPageRepository {

        IEnumerable<IWikiPage> GetPages();

        IWikiPage GetPage(string title);
        IWikiPage GetPage(int id);
        IWikiPage GetParentPage(string title);
        IWikiPage GetParentPage(int id);

        IWikiPage GetUserPage(string username);
        IWikiPage GetUserPage(int id);

        IQueryable<IWikiPage> GetChildPages(string title);
        IQueryable<IWikiPage> GetChildPages(int id);
        IQueryable<IWikiPage> GetPagesByUser(string userName);

        IWikiPage CreatePage();

        void Add(IWikiPage page);

        //void AddPageToTag(...);
        //void RemovePageFromTag(...);
        //void AddParent(...);
        //void RemoveParent(...);

        void Remove(IWikiPage page);

        void Save();
    }
}
