using Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Matches.Commands
{
    #region Query
    /// <summary>
    /// Class Query or Command
    /// All the data we need to execute
    /// </summary>
    /// 
    public class UpdateMatchScoreCommand : IRequest<UpdateMatch>
    {
        public string MatchId { get; set; }
        public int? HGoal { get; set; }
        public int? GGoal { get; set; }
        public UpdateMatchScoreCommand(string matchid,int? hGoal, int? ggoal)
        {
            MatchId = matchid;
            HGoal = hGoal;
            GGoal = ggoal;
        }
    }
    #endregion
    #region Handler
    public class UpdateMatchScoreHandler : IRequestHandler<UpdateMatchScoreCommand, UpdateMatch>
    {
        private readonly IMatchRepository _matchRepository;

        public UpdateMatchScoreHandler(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public async Task<UpdateMatch> Handle(UpdateMatchScoreCommand request, CancellationToken cancellationToken)
        {
            var match = await _matchRepository.GetByStrIdAsync(request.MatchId);
            match.GGoal = request.GGoal;
            match.HGoal = request.HGoal;
            await _matchRepository.UpdateAsync(match);
            //ReUse Model from matchRepository
            UpdateMatch updatematch = new UpdateMatch();
            #region Manual Mappping
            updatematch.MatchId = match.MatchId;

            updatematch.MatchNumber = match.MatchNumber;
            updatematch.DateMatch = match.DateMatch;
            updatematch.TimeMatch = match.TimeMatch;
            updatematch.MatchYear = match.MatchYear;
            updatematch.SeasonId = match.SeasonId;
            updatematch.Round = match.Round;
            /// <summary>
            /// Set value to Qualified for Qualified and Final for Final Round
            /// </summary>
            updatematch.Stage = match.Stage;
            updatematch.SubStage = match.SubStage;
            updatematch.HTeam = match.HTeam;
            updatematch.HGoal = match.HGoal;
            updatematch.GGoal = match.GGoal;
            updatematch.GTeam = match.GTeam;
            updatematch.WinNote = match.WinNote;
            updatematch.Referee = match.Referee;
            updatematch.Visistors = match.Visistors;
            updatematch.Status = match.Status;
            #endregion
            return updatematch;
        }
}
    #endregion
    #region Response
    public class UpdateMatch
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



