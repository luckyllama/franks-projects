namespace LuckyArmoryLibrary.Data.Type {

    public class DefensesData {
        public DefensesData() { }

        public int ArmorEffective { get; set; }
        public double ArmorPercent { get; set; }

        public double Defense { get; set; }
        public double DefenseIncreasePercent { get; set; }
        public double DefenseDecreasePercent { get; set; }

        public int DodgeRating { get; set; }
        public double DodgePercent { get; set; }

        public int ParryRating { get; set; }
        public double ParryPercent { get; set; }

        public int BlockRating { get; set; }
        public double BlockPercent { get; set; }

        public double ResilienceRating { get; set; }
        public double ResilienceDamagePercent { get; set; }
        public double ResilienceHitPercent { get; set; }
    }
}