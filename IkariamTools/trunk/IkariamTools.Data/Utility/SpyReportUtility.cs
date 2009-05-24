using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IkariamTools.Data.Models;

namespace IkariamTools.Data.Utility {
    public class SpyReportUtility {
        
        public static int GetLootableQuantity(int quantity, int warehouseLevel) {
            return Math.Max(quantity - (int)(180 + (80 * (warehouseLevel - 1))), 0);
        }

        public static int GetTotalQuantity(ISpyReport report) {
            return
                report.WoodQuantity +
                report.WineQuantity +
                report.MarbleQuantity +
                report.CrystalQuantity +
                report.SulphurQuantity;
        }

        public static int GetTotalLootableQuantity(ISpyReport report, int warehouseLevel) {
            return
                GetLootableQuantity(report.WoodQuantity, warehouseLevel) +
                GetLootableQuantity(report.WineQuantity, warehouseLevel) +
                GetLootableQuantity(report.MarbleQuantity, warehouseLevel) +
                GetLootableQuantity(report.CrystalQuantity, warehouseLevel) +
                GetLootableQuantity(report.SulphurQuantity, warehouseLevel);
        }
        
    }
}
