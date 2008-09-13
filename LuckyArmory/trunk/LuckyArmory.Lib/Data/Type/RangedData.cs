namespace LuckyArmory.Lib.Data.Type {

    public class RangedData {
        public RangedData() {}

        public double WeaponDps { get; set; }
        public int WeaponMax { get; set; }
        public int WeaponMin { get; set; }
        public double WeaponSpeed { get; set; }

        public int PowerBase { get; set; }
        public int PowerEffective { get; set; }

        public int HitRating { get; set; }
        public double HitRatingPercent { get; set; }

        public int CritChanceRating { get; set; }
        public double CritChancePercent { get; set; }

        public bool HasRanged {
            get {
                if (System.Convert.ToInt32(WeaponMax) > 0) {
                    return true;
                }
                return false;
            }
        }
    }
}