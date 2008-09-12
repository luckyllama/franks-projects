using System;
using System.Collections.Generic;
namespace LuckyArmoryLibrary.Data.Type {

    public class SpellData {
        public SpellData() {}

        public int BonusDamageArcane { get; set; }
        public int BonusDamageFire { get; set; }
        public int BonusDamageFrost { get; set; }
        public int BonusDamageHoly { get; set; }
        public int BonusDamageNature { get; set; }
        public int BonusDamageShadow { get; set; }

        private int bonusDamageMode = -1;
        public int BonusDamageMode {
            get {
                if (bonusDamageMode == -1) {

                    int[] bonusDamage = {
                                            BonusDamageArcane, BonusDamageFire, 
                                            BonusDamageFrost, BonusDamageHoly, 
                                            BonusDamageNature, BonusDamageShadow,
                                        };

                    bonusDamageMode = Utility.GetStatisticalMode<int>(bonusDamage);
                }

                return bonusDamageMode;
            }
        }

        public int BonusHealing { get; set; }

        public int HitRating { get; set; }
        public double HitRatingPercent { get; set; }

        public int CritChanceRating { get; set; }
        public double CritChancePercentArcane { get; set; }
        public double CritChancePercentFire { get; set; }
        public double CritChancePercentFrost { get; set; }
        public double CritChancePercentHoly { get; set; }
        public double CritChancePercentNature { get; set; }
        public double CritChancePercentShadow { get; set; }

        private double critChancePercentageMode = -1;
        public double CritChancePercentageMode {
            get {
                if (critChancePercentageMode == -1) {

                    double[] critChance = {
                                            CritChancePercentArcane, CritChancePercentFire, 
                                            CritChancePercentFrost, CritChancePercentHoly, 
                                            CritChancePercentNature, CritChancePercentShadow,
                                        };

                    critChancePercentageMode = Utility.GetStatisticalMode<double>(critChance);
                }

                return critChancePercentageMode;
            }
        }

        public int PenetrationRating { get; set; }

        public double ManaRegenCasting { get; set; }
        public double ManaRegenNotCasting { get; set; }
    }
}