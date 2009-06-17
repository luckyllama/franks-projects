
using System.Collections.Generic;
namespace IkariamTools.Data.Models {
    public interface ICity {
        int Id { get; set; }
        int? IkariamId { get; set; }
        string CityName { get; set; }
        IPlayer Player { get; set; }
        byte? X { get; set; }
        byte? Y { get; set; }
        ResourceType Resource { get; set; }
        byte? Size { get; set; }
        byte? Wall { get; set; }
        byte? Warehouse { get; set; }
        bool? IsCapital { get; set; }
        int? DeltaWood { get; set; }
        int? DeltaWine { get; set; }
        int? DeltaMarble { get; set; }
        int? DeltaCrystal { get; set; }
        int? DeltaSulphur { get; set; }
        string Notes { get; set; }

        List<ICombatReport> CombatReports { get; }
        List<ISpyReport> SpyReports { get; }
    }
}
