using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    // Tournaments
    public class Tournament
    {
        #region Properties
        public string TournamentId { get; set; }

        public string TourName { get; set; }

        public string FederationName { get; set; }
        public bool IsActive { get; set; }
        #endregion

        #region RelationShip
        public Federation Federations { get; set; } //Each Federations can contain many Tournaments
        public virtual ICollection<Season> Seasons { get; set; } //Each Tournament contain many Season.
        #endregion

    }
}