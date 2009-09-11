using System;
using System.Linq;
using LuckyWiki.Data;

namespace LuckyWiki.Data.LinqToSqlDataProvider {

    public class LuckyWikiLinqToSqlDataProvider : ILuckyWikiDataProvider {
        
        private string connectionString;
        public LuckyWikiLinqToSqlDataProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }        

        private LuckyWikiDataContext dataContext;
        public LuckyWikiDataContext DataContext {
            get {
                if (dataContext == null) {
                    dataContext = new LuckyWikiDataContext(connectionString);
                }

                return dataContext;
            }
        }

        #region ILuckyWikiDataProvider Members

        private IWikiPageRepository wikiPageRepository;
        public virtual IWikiPageRepository WikiPageRepository {
            get {
                if (wikiPageRepository == null) {
                    wikiPageRepository = new WikiPageRepository(DataContext);
                }
                return wikiPageRepository;
            }
        }

        private IMembershipRepository membershipRepository;
        public virtual IMembershipRepository MembershipRepository {
            get {
                if (membershipRepository == null) {
                    membershipRepository = new MembershipRepository(DataContext);
                }
                return membershipRepository;
            }
        }

        #endregion ILuckyWikiDataProvider Members

    }
}
