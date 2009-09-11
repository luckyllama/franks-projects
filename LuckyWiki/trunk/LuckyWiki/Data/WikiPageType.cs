using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyWiki.Data {
    
    public enum WikiPageTypes : byte { 
        Page = 1,
        UserPage,
        Tag, 
        Template,
        Unknown
    }

}
