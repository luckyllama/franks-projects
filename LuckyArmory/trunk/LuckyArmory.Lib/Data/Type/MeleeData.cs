namespace LuckyArmory.Lib.Data.Type {

    public class MeleeData {
        public MeleeData() {}

        public double MainHandDps { get; set; }
        public int MainHandMax { get; set; }
        public int MainHandMin { get; set; }
        public double MainHandSpeed { get; set; }

        public double OffHandDps { get; set; }
        public int OffHandMax { get; set; }
        public int OffHandMin { get; set; }
        public double OffHandSpeed { get; set; }

        public int PowerBase { get; set; }
        public int PowerEffective { get; set; }

        public int HitRating { get; set; }
        public double HitRatingPercent { get; set; }

        public int CritChanceRating { get; set; }
        public double CritChancePercent { get; set; }

        public int ExpertiseRating { get; set; }
        public double ExpertisePercent { get; set; }

        public bool HasOffHandWeapon {
            get {
                if (System.Convert.ToInt32(OffHandMin) > 0) {
                    return true;
                }
                return false;
            }
        }
    }
}