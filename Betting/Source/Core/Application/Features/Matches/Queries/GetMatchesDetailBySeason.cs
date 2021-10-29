using Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Matches.Queries
{
    #region Query
    /// <summary>
    /// Class Query or Command
    /// All the data we need to execute
    /// </summary>   
    public class GetMatchesDetailBySeason : IRequest<IEnumerable<MatchesDetailBySeason>>
    {
        public string seasonID { get; }
        public GetMatchesDetailBySeason(string seasonID)
        {
            this.seasonID = seasonID;
        }
    }
    #endregion
    #region Handler
    /// <summary>
    /// The Handler all the Business Logic we need to execute and reponse Data
    /// </summary>
    public class GetMatchesDetailBySeasonHandler : IRequestHandler<GetMatchesDetailBySeason, IEnumerable<MatchesDetailBySeason>>
    {
        private readonly IMatchRepository _matchRepository;

        public GetMatchesDetailBySeasonHandler(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public async Task<IEnumerable<MatchesDetailBySeason>> Handle(GetMatchesDetailBySeason request, CancellationToken cancellationToken)
        {
            var matchlist = _matchRepository.GetMatchDetailBySeasonAsync(request.seasonID);
            return matchlist;
        }        
    }    
    #endregion
    #region Response
    public class MatchesDetailBySeason
    {
        public string MatchId { get; set; }
        public int MatchNumber { get; set; }
        public DateTime DateMatch { get; set; }
        public TimeSpan TimeMatch { get; set; }
        public int MatchYear { get; set; }
        public string SeasonId { get; set; }
        public string SeasonName { get; set; }
        public string Round { get; set; }
        /// <summary>
        /// Set value to Qualified for Qualified and Final for Final Round
        /// </summary>
        public string Stage { get; set; }
        public string SubStage { get; set; }
        public string HTeam { get; set; }
        public string HTeamCode { get; set; } //For Flag get from Table Team from Foreign Key TeamName
        public int? HGoal { get; set; }
        public int? GGoal { get; set; }
        public string GTeam { get; set; }
        public string GTeamCode { get; set; }
        public string WinNote { get; set; }
        public string Stadium { get; set; }
        public string Referee { get; set; }
        public long? Visistors { get; set; }
        public string Status { get; set; }
    }    
    #endregion     
    

    
    
    

}
