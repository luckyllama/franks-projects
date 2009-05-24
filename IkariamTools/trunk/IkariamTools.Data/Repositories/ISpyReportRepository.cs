using IkariamTools.Data.Models;

namespace IkariamTools.Data {
    public interface ISpyReportRepository {
        void Add(ISpyReport spyReport);
        void Remove(ISpyReport spyReport);

        void Save();
    }
}
