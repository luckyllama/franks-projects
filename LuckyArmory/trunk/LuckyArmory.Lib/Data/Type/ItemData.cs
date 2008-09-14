using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyArmory.Lib.Data.Type {
    public class ItemData {
        public ItemData() { }

        public int Slot { get; set; }

        public int Id { get; set; }

        public string Icon { get; set; }

        public int Gem0Id { get; set; }

        public int Gem1Id { get; set; }

        public int Gem2Id { get; set; }

        public int EnchantId { get; set; }
    }
}
