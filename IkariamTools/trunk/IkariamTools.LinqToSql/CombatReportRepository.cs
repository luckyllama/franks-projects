using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IkariamTools.Data;
using IkariamTools.Data.Models;

namespace IkariamTools.LinqToSql {
    public class CombatReportRepository : ICombatReportRepository {

        private readonly IkariamToolsDataContext dataContext;

        public CombatReportRepository() {
            dataContext = new IkariamToolsDataContext();
        }

        #region ICombatReportRepository Members

        public void Add(ICombatReport combatReport) {
            dataContext.CombatReports.InsertOnSubmit((CombatReport)combatReport);
        }

        public void Remove(ICombatReport combatReport) {
            dataContext.CombatReports.DeleteOnSubmit((CombatReport)combatReport);
        }

        public void Save() {
            dataContext.SubmitChanges();
        }

        #endregion
    }
}
