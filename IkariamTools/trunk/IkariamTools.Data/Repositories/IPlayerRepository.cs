using System.Linq;
using IkariamTools.Data.Models;

namespace IkariamTools.Data {
    public interface IPlayerRepository {
        IQueryable<IPlayer> GetPlayers();
        IPlayer GetPlayer(string playerName);

        void Add(IPlayer player);
        void Remove(IPlayer player);

        void Save();
    }
}
