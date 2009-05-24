using System.Collections.Generic;

namespace IkariamTools.Data.Models {
    public interface IPlayer {
        int Id { get; set; }
        string PlayerName { get; set; }
        List<ICity> Cities { get; }
        int? TotalScore { get; set; }
        int? MilitaryScore { get; set; }
        bool IsActive { get; set; }
        bool IsDeleted { get; set; }
    }
}
