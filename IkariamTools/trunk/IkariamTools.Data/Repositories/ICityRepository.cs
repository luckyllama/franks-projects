using System.Linq;
using IkariamTools.Data.Models;

namespace IkariamTools.Data {
    public interface ICityRepository {
        IQueryable<ICity> GetCities();
        IQueryable<ICity> GetDeletedCities();
        IQueryable<ICity> GetCities(string cityName);
        IQueryable<ICity> GetCities(int x, int y);
        IQueryable<ICity> GetCities(ResourceType resource);
        IQueryable<ICity> GetCities(bool isActive);

        void Add(ICity city);
        void Remove(ICity city);

        void Save();
    }
}
