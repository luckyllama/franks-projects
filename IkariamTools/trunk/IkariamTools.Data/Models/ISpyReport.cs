using System;

namespace IkariamTools.Data.Models {
    public interface ISpyReport {
        int Id { get; set; }
        ICity City { get; }
        int WoodQuantity { get; set; }
        int WineQuantity { get; set; }
        int MarbleQuantity { get; set; }
        int CrystalQuantity { get; set; }
        int SulphurQuantity { get; set; }
        DateTime Date { get; set; }
    }
}
