using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IkariamTools.Data.Models;

namespace IkariamTools.Data.Utility {
    public static class CityExtensions {

        #region Total Resource Quantities

        public static int TotalWoodQuantity(this ICity city) {
            if (city.SpyReports.Count > 0) {
                if (city.CombatReports.Count > 0 && city.CombatReports[0].WoodLooted.HasValue) {
                    return city.SpyReports[0].WoodQuantity - (int)city.CombatReports[0].WoodLooted;
                } else {
                    return city.SpyReports[0].WoodQuantity;
                }
            } else {
                return -1;
            }
        }

        public static int TotalWineQuantity(this ICity city) {
            if (city.SpyReports.Count > 0) {
                if (city.CombatReports.Count > 0 && city.CombatReports[0].WineLooted.HasValue) {
                    return city.SpyReports[0].WineQuantity - (int)city.CombatReports[0].WineLooted;
                } else {
                    return city.SpyReports[0].WineQuantity;
                }
            } else {
                return -1;
            }
        }

        public static int TotalMarbleQuantity(this ICity city) {
            if (city.SpyReports.Count > 0) {
                if (city.CombatReports.Count > 0 && city.CombatReports[0].MarbleLooted.HasValue) {
                    return city.SpyReports[0].MarbleQuantity - (int)city.CombatReports[0].MarbleLooted;
                } else {
                    return city.SpyReports[0].MarbleQuantity;
                }
            } else {
                return -1;
            }
        }

        public static int TotalCrystalQuantity(this ICity city) {
            if (city.SpyReports.Count > 0) {
                if (city.CombatReports.Count > 0 && city.CombatReports[0].CrystalLooted.HasValue) {
                    return city.SpyReports[0].CrystalQuantity - (int)city.CombatReports[0].CrystalLooted;
                } else {
                    return city.SpyReports[0].CrystalQuantity;
                }
            } else {
                return -1;
            }
        }

        public static int TotalSulphurQuantity(this ICity city) {
            if (city.SpyReports.Count > 0) {
                if (city.CombatReports.Count > 0 && city.CombatReports[0].SulphurLooted.HasValue) {
                    return city.SpyReports[0].SulphurQuantity - (int)city.CombatReports[0].SulphurLooted;
                } else {
                    return city.SpyReports[0].SulphurQuantity;
                }
            } else {
                return -1;
            }
        }

        public static int TotalResourceQuantity(this ICity city) {
            return
                city.TotalWoodQuantity() +
                city.TotalWineQuantity() +
                city.TotalMarbleQuantity() +
                city.TotalCrystalQuantity() +
                city.TotalSulphurQuantity();
        }

        #endregion Total Resource Quantities

        #region Total Lootable Resource Quantity

        public static int TotalLootableWoodQuantity(this ICity city) {
            if (city.Warehouse.HasValue) {
                return getLootableQuantity(city.TotalWoodQuantity(), (int)city.Warehouse);
            } else {
                return -1;
            }
        }

        public static int TotalLootableWineQuantity(this ICity city) {
            if (city.Warehouse.HasValue) {
                return getLootableQuantity(city.TotalWineQuantity(), (int)city.Warehouse);
            } else {
                return -1;
            }
        }

        public static int TotalLootableMarbleQuantity(this ICity city) {
            if (city.Warehouse.HasValue) {
                return getLootableQuantity(city.TotalMarbleQuantity(), (int)city.Warehouse);
            } else {
                return -1;
            }
        }

        public static int TotalLootableCrystalQuantity(this ICity city) {
            if (city.Warehouse.HasValue) {
                return getLootableQuantity(city.TotalCrystalQuantity(), (int)city.Warehouse);
            } else {
                return -1;
            }
        }

        public static int TotalLootableSulphurQuantity(this ICity city) {
            if (city.Warehouse.HasValue) {
                return getLootableQuantity(city.TotalSulphurQuantity(), (int)city.Warehouse);
            } else {
                return -1;
            }
        }

        private static int getLootableQuantity(int quantity, int warehouseLevel) {
            return Math.Max(quantity - (int)(180 + (80 * (warehouseLevel - 1))), 0);
        }

        public static int TotalLootableQuantity(this ICity city) {
            return
                city.TotalLootableWoodQuantity() +
                city.TotalLootableWineQuantity() +
                city.TotalLootableMarbleQuantity() +
                city.TotalLootableCrystalQuantity() +
                city.TotalLootableSulphurQuantity();
        }

        #endregion Total Lootable Resource Quantity

        #region Last Action 

        public static string LastActionType(this ICity city) {
            if (city.SpyReports.Count > 0) {
                if (city.CombatReports.Count > 0 && city.CombatReports[0].Date > city.SpyReports[0].Date) {
                    return "Combat";
                } else {
                    return "Spy";
                }
            } else if (city.CombatReports.Count > 0) {
                return "Spy";
            } else {
                return "";
            }
        }

        public static DateTime? LastAction(this ICity city) {
            if (city.LastActionType() == "Combat") {
                return city.CombatReports[0].Date;
            } else if (city.LastActionType() == "Spy") {
                return city.SpyReports[0].Date;
            } else {
                return null;
            }
        }

        #endregion Last Action

    }
}
