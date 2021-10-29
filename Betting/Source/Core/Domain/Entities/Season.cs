using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Season
    {

        #region Properties
        public string SeasonId { get; set; }

        public string SeasonName { get; set; }
        public string TournamentId { get; set; }        
        public bool IsFinished { get; set; }
        #endregion

        #region RelationShip
        public virtual Tournament Tournaments { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
        #endregion     
    }
}
