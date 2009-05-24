using System;

namespace IkariamTools.Data.Models {
    public interface ICombatReport {
        int Id { get; set; }
        ICity City { get; }
        int? WoodLooted { get; set; }
        int? WineLooted { get; set; }
        int? MarbleLooted { get; set; }
        int? CrystalLooted { get; set; }
        int? SulphurLooted { get; set; }
        DateTime Date { get; set; }
    }
}
