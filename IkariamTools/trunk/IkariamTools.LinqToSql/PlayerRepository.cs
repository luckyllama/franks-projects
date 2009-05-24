using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IkariamTools.Data;
using IkariamTools.Data.Models;

namespace IkariamTools.LinqToSql {
    public class PlayerRepository : IPlayerRepository {

        private readonly IkariamToolsDataContext dataContext;

        public PlayerRepository() {
            dataContext = new IkariamToolsDataContext();
        }

        #region IPlayerRepository Members

        public IQueryable<IPlayer> GetPlayers() {
            return dataContext.Players.Where(p => p.IsDeleted == false).Cast<IPlayer>();
        }

        public IPlayer GetPlayer(string playerName) {
            return dataContext.Players.Single(p => p.PlayerName == playerName);
        }

        public void Add(IPlayer player) {
            dataContext.Players.InsertOnSubmit((Player)player);
        }

        public void Remove(IPlayer player) {
            dataContext.Players.DeleteOnSubmit((Player)player);
        }

        public void Save() {
            dataContext.SubmitChanges();
        }

        #endregion
    }
}
