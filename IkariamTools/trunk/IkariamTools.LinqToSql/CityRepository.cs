using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IkariamTools.Data;
using IkariamTools.Data.Models;
using System.Data.Linq;

namespace IkariamTools.LinqToSql {
    public class CityRepository : ICityRepository {

        private readonly IkariamToolsDataContext dataContext;

        public CityRepository() {
            dataContext = new IkariamToolsDataContext();

            DataLoadOptions options = new DataLoadOptions();
            options.LoadWith<City>(c => c.Player);
            options.LoadWith<City>(c => c.SpyReports);
            options.LoadWith<City>(c => c.CombatReports);

            dataContext.LoadOptions = options;
        }

        #region ICityRepository Members

        public IQueryable<ICity> GetCities() {
            return dataContext.Cities.Where(c => c.Player.IsDeleted == false).Cast<ICity>();
        }

        public IQueryable<ICity> GetDeletedCities() {
            return dataContext.Cities.Where(c => c.Player.IsDeleted == true).Cast<ICity>();
        }

        public IQueryable<ICity> GetCities(string cityName) {
            return dataContext.Cities.Where(c => c.CityName == cityName).Cast<ICity>();
        }

        public IQueryable<ICity> GetCities(int x, int y) {
            return dataContext.Cities.Where(c => c.X == x && c.Y == y).Cast<ICity>();
        }

        public IQueryable<ICity> GetCities(ResourceType resource) {
            return dataContext.Cities.Where(c => c.ResourceType == resource.ToString()).Cast<ICity>();
        }

        public IQueryable<ICity> GetCities(bool isActive) {
            return dataContext.Cities.Where(c => c.Player.IsActive == isActive).Cast<ICity>();
        }

        public void Add(ICity city) {
            dataContext.Cities.InsertOnSubmit((City)city);
        }

        public void Remove(ICity city) {
            dataContext.Cities.DeleteOnSubmit((City)city);
        }

        public void Save() {
            dataContext.SubmitChanges(ConflictMode.FailOnFirstConflict);
        }

        #endregion
    }
}
