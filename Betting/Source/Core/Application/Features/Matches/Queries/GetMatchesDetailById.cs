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
    public class GetMatchesDetailById : IRequest<MatchesDetailById>
    {
        public string MatchId { get; }

        public GetMatchesDetailById(string matchId)
        {
            MatchId = matchId;
        }
    }
    #endregion
    #region Handler
    /// <summary>
    /// The Handler all the Business Logic we need to execute and reponse Data
    /// </summary>

    public class GetMatchesDetailByIdHandler : IRequestHandler<GetMatchesDetailById, MatchesDetailById>
    {
        private readonly IMatchRepository _matchRepository;

        public GetMatchesDetailByIdHandler(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public async Task<IEnumerable<MatchesDetailByTeamName>> Handle(GetMatchesDetailByTeamName request, CancellationToken cancellationToken)
        {
            var matchlist = _matchRepository.GetMatchDetailByTeamNameAsync(request.teamName);
            //ReUse Model from matchRepository
            return matchlist;
        }

        public async Task<MatchesDetailById> Handle(GetMatchesDetailById request, CancellationToken cancellationToken)
        {
            var match = _matchRepository.GetMatchDetailByMatchStrId(request.MatchId);            
            return match;
        }
    }
    #endregion

    #region Response
    public class MatchesDetailById
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
