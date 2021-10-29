using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Match
    {
        public string MatchId { get; set; }
        public int MatchNumber { get; set; }
        public DateTime DateMatch { get; set; }
        public TimeSpan TimeMatch { get; set; }
        public int MatchYear { get; set; }
        public string SeasonId { get; set; }
        /// <summary>
        /// Round have value Qualified for qualify and final for Final Round
        /// </summary>
        public string Round { get; set; } 
        /// <summary>
        /// Stage have two value: Group and KnockOut
        /// </summary>        
        public string Stage { get; set; }
        public string SubStage { get; set; }
        public string HTeam { get; set; }
        public int? HGoal { get; set; }
        public int? GGoal { get; set; }
        public string GTeam { get; set; }
        public string WinNote { get; set; }
        public string Stadium { get; set; }
        public string Referee { get; set; }
        public long? Visistors { get; set; }
        public string Status { get; set; }
        #region RelationShip
        public virtual Season Seasons { get; set; }
            public virtual Team HomeTeam { get; set; } 
            public virtual Team GuestTeam { get; set; }
            //public Country Countries { get; set; }          
        #endregion

    }
}
