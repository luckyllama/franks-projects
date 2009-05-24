using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IkariamTools.Data.Models;

namespace IkariamTools.LinqToSql {

    partial class IkariamToolsDataContext {
        public IkariamToolsDataContext()
            : base(System.Configuration.ConfigurationManager.ConnectionStrings["IkariamToolsConnectio"].ConnectionString) { }
    }

    partial class City : ICity {

        #region ICity Members

        public ResourceType Resource {
            get {
                return (ResourceType)Enum.Parse(typeof(ResourceType), this.ResourceType);
            }
            set {
                this.ResourceType = value.ToString();
            }
        }

        IPlayer ICity.Player {
            get {
                return (IPlayer)this.Player;
            }
            set {
                throw new NotImplementedException();
            }
        }

        List<ICombatReport> ICity.CombatReports {
            get {
                return this.CombatReports.Cast<ICombatReport>().ToList<ICombatReport>();
            }
        }

        List<ISpyReport> ICity.SpyReports {
            get {
                return this.SpyReports.Cast<ISpyReport>().ToList<ISpyReport>();
            }
        }

        #endregion
    
    }

    partial class Player : IPlayer {

        #region IPlayer Members


        List<ICity> IPlayer.Cities {
            get {
                return this.Cities.Cast<ICity>().ToList<ICity>();
            }
        }

        #endregion
    
    }

    partial class SpyReport : ISpyReport {

        #region ISpyReport Members

        ICity ISpyReport.City {
            get {
                return (ICity)this.City;
            }
        }

        #endregion

    }

    partial class CombatReport : ICombatReport {

        #region ICombatReport Members

        ICity ICombatReport.City {
            get {
                return (ICity)this.City;
            }
        }

        #endregion

    }
}
