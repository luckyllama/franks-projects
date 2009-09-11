using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyWiki.Data {

    public enum UserStatus : byte {
        Normal = 1,
        Deleted,
        Banned,
        Unknown
    }

}
