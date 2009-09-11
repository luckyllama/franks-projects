using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyWiki.Data {
    public interface IWikiPage {
        
        int Id { get; }
        IWikiPage Parent { get; }
        IEnumerable<IWikiPage> Children { get; }
        string Title { get; set; }
        string Content { get; set; }
        WikiPageTypes WikiPageType { get; set; }

        DateTime Created { get; set; }
        IUser CreatingUser { get; set; }
        DateTime? Modified { get; set; }
        IUser ModifyingUser { get; set; }

        IEnumerable<ITag> Tags { get; }
    }
}
