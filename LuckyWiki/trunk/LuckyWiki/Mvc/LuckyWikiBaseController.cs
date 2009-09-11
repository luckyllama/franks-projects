using System;
using System.Web.Mvc;
using LuckyWiki.Authentication;
using System.Web;
using LuckyWiki.Data;
using LuckyWiki.Configuration;
using System.Configuration;

namespace LuckyWiki.Mvc {
    public class LuckyWikiBaseController : Controller {

        protected IWikiPageRepository WikiPageRepository;
        protected IMembershipRepository MembershipRepository;
        protected IFormsAuthentication FormsAuthentication;

        public LuckyWikiBaseController() {
            LuckyWikiConfigurationSection config = (LuckyWikiConfigurationSection)ConfigurationManager.GetSection("luckyWiki");
            ILuckyWikiDataProvider dataProvider = config.DataProvider.GetInstance();
            MembershipRepository = dataProvider.MembershipRepository;
            WikiPageRepository = dataProvider.WikiPageRepository;
            FormsAuthentication = new FormsAuthenticationService();
        }

        private IUser user;
        public new IUser User {
            get {
                if (user == null) {
                    if (base.User.Identity.IsAuthenticated) {
                        user = MembershipRepository.GetUser(base.User.Identity.Name);
                    } else {
                        user = MembershipRepository.GetAnonymousUser(System.Web.HttpContext.Current.Request.UserHostAddress);
                        FormsAuthentication.SignIn(System.Web.HttpContext.Current.Request.UserHostAddress, false /* setPersistantCookie */);
                    }
                }

                return user;
            }
        }

    }
}
