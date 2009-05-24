using IkariamTools.Data.Models;

namespace IkariamTools.Data {
    public interface ICombatReportRepository {
        void Add(ICombatReport combatReport);
        void Remove(ICombatReport combatReport);

        void Save();
    }
}
