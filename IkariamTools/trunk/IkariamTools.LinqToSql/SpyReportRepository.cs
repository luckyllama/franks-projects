using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IkariamTools.Data;
using IkariamTools.Data.Models;

namespace IkariamTools.LinqToSql {
    public class SpyReportRepository : ISpyReportRepository {

        private readonly IkariamToolsDataContext dataContext;

        public SpyReportRepository() {
            dataContext = new IkariamToolsDataContext();
        }

        #region ISpyReportRepository Members

        public void Add(ISpyReport spyReport) {
            dataContext.SpyReports.InsertOnSubmit((SpyReport)spyReport);
        }

        public void Remove(ISpyReport spyReport) {
            dataContext.SpyReports.DeleteOnSubmit((SpyReport)spyReport);
        }

        public void Save() {
            dataContext.SubmitChanges();
        }

        #endregion
    }
}
