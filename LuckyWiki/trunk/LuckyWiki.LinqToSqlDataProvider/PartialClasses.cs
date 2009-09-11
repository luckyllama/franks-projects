using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyWiki.Data.LinqToSqlDataProvider {
    partial class WikiPage : IWikiPage {

        #region IWikiPage Members

        public IEnumerable<ITag> Tags {
            get { return this.WikiPage_Tags.Select(ptr => ptr.Tag).Cast<ITag>(); }
        }

        IWikiPage IWikiPage.Parent {
            get { return this.Parent; }
        }

        IEnumerable<IWikiPage> IWikiPage.Children {
            get { return this.Children.Cast<IWikiPage>(); }
        }

        public WikiPageTypes WikiPageType {
            get {
                return (WikiPageTypes)WikiPageTypeId;
            }
            set {
                WikiPageTypeId = (byte)value;
            }
        }

        IUser IWikiPage.CreatingUser {
            get { return this.CreatingUser; }
            set {
                this.CreatedByUserId = value.Id;
                this.SendPropertyChanged("CreatingUser");
            }
        }

        IUser IWikiPage.ModifyingUser {
            get { return this.ModifyingUser; }
            set {
                this.ModifiedByUserId = value.Id;
                this.SendPropertyChanged("ModifyingUser");
            }
        }

        #endregion

    }

    partial class User : IUser {

        #region IUser Members
        
        public UserStatus Status {
            get {
                return (UserStatus)StatusId;
            }
            set {
                StatusId = (byte)value;
            }
        }

        #endregion
    }

    partial class Tag : ITag { 
    
    }
}
