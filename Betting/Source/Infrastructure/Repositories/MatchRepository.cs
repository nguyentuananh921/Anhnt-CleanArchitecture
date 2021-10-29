using Application.Features.Matches.Queries;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Database.DatabaseContext;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MatchRepository : GenericRepository<Match>, IMatchRepository
    {
        //private readonly DbSet<Match> _match;
        public MatchRepository(ApplicationDbContext context):base(context)
        {
            //No More private here
            //_context = context;
        }       

        public IEnumerable<MatchesDetail> GetMatchDetailAsync()
        {
            #region TryOther way
            var matchQuery = (from match in _context.Matches
                                   join team1 in _context.Teams on match.HTeam equals team1.TeamName
                                   join team2 in _context.Teams on match.GTeam equals team2.TeamName
                                   join season in _context.Seasons on match.SeasonId equals season.SeasonId
                              orderby match.MatchYear descending, match.MatchNumber
                              select new
                                   {
                                       #region selectResult
                                           match.MatchId,
                                           match.MatchNumber,
                                           match.DateMatch,
                                           match.TimeMatch,
                                           match.MatchYear,
                                           match.SeasonId,
                                           season.SeasonName,
                                           match.Round,
                                           match.Stage,
                                           match.SubStage,
                                           match.HTeam,
                                           HTeamCode = team1.TeamCode,
                                           match.HGoal,
                                           match.GGoal,
                                           match.GTeam,
                                           GTeamCode = team2.TeamCode,
                                           match.WinNote,
                                           match.Stadium,
                                           match.Referee,
                                           match.Visistors
                                       #endregion
                                   });
            //MatchesDetail matchesDetail = new MatchesDetail();
            List<MatchesDetail> retList = new List<MatchesDetail>();
            //IEnumerable<MatchesDetail> retList;
            foreach (var item in matchQuery)
            {
                MatchesDetail matchesDetail = new MatchesDetail();
                #region ManualMapping
                matchesDetail.MatchId = item.MatchId;
                    matchesDetail.MatchNumber = item.MatchNumber;
                    matchesDetail.DateMatch = item.DateMatch;
                    matchesDetail.TimeMatch = item.TimeMatch;
                    matchesDetail.MatchYear = item.MatchYear;
                    matchesDetail.SeasonId = item.SeasonId;
                    matchesDetail.SeasonName = item.SeasonName;
                    matchesDetail.Round = item.Round;
                    matchesDetail.Stage = item.Stage;
                    matchesDetail.SubStage = item.SubStage;
                    matchesDetail.HTeam = item.HTeam;
                    matchesDetail.HGoal = item.HGoal;
                    matchesDetail.HTeamCode = item.HTeamCode;
                    matchesDetail.GGoal = item.GGoal;
                    matchesDetail.GTeam = item.GTeam;
                    matchesDetail.GTeamCode = item.GTeamCode;
                    matchesDetail.WinNote = item.WinNote;
                    matchesDetail.Stadium = item.Stadium;
                    matchesDetail.Referee = item.Referee;
                    matchesDetail.Visistors = item.Visistors;
                #endregion
                retList.Add(matchesDetail);
            }
            #endregion
            
            return retList;

        }
        public IEnumerable<MatchesDetailByTeamName> GetMatchDetailByTeamNameAsync(string teamname)
        {
            #region TryOther way
            var matchQuery = (from match in _context.Matches
                              join team1 in _context.Teams on match.HTeam equals team1.TeamName
                              join team2 in _context.Teams on match.GTeam equals team2.TeamName
                              join season in _context.Seasons on match.SeasonId equals season.SeasonId
                              where (team1.TeamName == teamname) || (team2.TeamName == teamname)
                              orderby match.MatchYear descending, match.MatchNumber
                              select new
                              {
                                  #region selectResult
                                  match.MatchId,
                                  match.MatchNumber,
                                  match.DateMatch,
                                  match.TimeMatch,
                                  match.MatchYear,
                                  match.SeasonId,
                                  season.SeasonName,
                                  match.Round,
                                  match.Stage,
                                  match.SubStage,
                                  match.HTeam,
                                  HTeamCode = team1.TeamCode,
                                  match.HGoal,
                                  match.GGoal,
                                  match.GTeam,
                                  GTeamCode = team2.TeamCode,
                                  match.WinNote,
                                  match.Stadium,
                                  match.Referee,
                                  match.Visistors
                                  #endregion
                              });            
            List<MatchesDetailByTeamName> retList = new List<MatchesDetailByTeamName>();            
            foreach (var item in matchQuery)
            {
                MatchesDetailByTeamName matchesDetail = new MatchesDetailByTeamName();
                #region ManualMapping
                matchesDetail.MatchId = item.MatchId;
                matchesDetail.MatchNumber = item.MatchNumber;
                matchesDetail.DateMatch = item.DateMatch;
                matchesDetail.TimeMatch = item.TimeMatch;
                matchesDetail.MatchYear = item.MatchYear;
                matchesDetail.SeasonId = item.SeasonId;
                matchesDetail.SeasonName = item.SeasonName;
                matchesDetail.Round = item.Round;
                matchesDetail.Stage = item.Stage;
                matchesDetail.SubStage = item.SubStage;
                matchesDetail.HTeam = item.HTeam;
                matchesDetail.HGoal = item.HGoal;
                matchesDetail.HTeamCode = item.HTeamCode;
                matchesDetail.GGoal = item.GGoal;
                matchesDetail.GTeam = item.GTeam;
                matchesDetail.GTeamCode = item.GTeamCode;
                matchesDetail.WinNote = item.WinNote;
                matchesDetail.Stadium = item.Stadium;
                matchesDetail.Referee = item.Referee;
                matchesDetail.Visistors = item.Visistors;
                #endregion
                retList.Add(matchesDetail);
            }
            #endregion

            return retList;
        }
        public IEnumerable<MatchesDetailBySeason> GetMatchDetailBySeasonAsync(string seasonId)
        {
            #region TryOther way
            var matchQuery = (from match in _context.Matches
                              join team1 in _context.Teams on match.HTeam equals team1.TeamName
                              join team2 in _context.Teams on match.GTeam equals team2.TeamName
                              join season in _context.Seasons on match.SeasonId equals season.SeasonId
                              where (season.SeasonId== seasonId)
                              orderby match.MatchYear descending, match.MatchNumber
                              select new
                              {
                                  #region selectResult
                                  match.MatchId,
                                  match.MatchNumber,
                                  match.DateMatch,
                                  match.TimeMatch,
                                  match.MatchYear,
                                  match.SeasonId,
                                  season.SeasonName,
                                  match.Round,
                                  match.Stage,
                                  match.SubStage,
                                  match.HTeam,
                                  HTeamCode = team1.TeamCode,
                                  match.HGoal,
                                  match.GGoal,
                                  match.GTeam,
                                  GTeamCode = team2.TeamCode,
                                  match.WinNote,
                                  match.Stadium,
                                  match.Referee,
                                  match.Visistors
                                  #endregion
                              });            
            List<MatchesDetailBySeason> retList = new List<MatchesDetailBySeason>();            
            foreach (var item in matchQuery)
            {
                MatchesDetailBySeason matchesDetail = new MatchesDetailBySeason();
                #region ManualMapping
                matchesDetail.MatchId = item.MatchId;
                matchesDetail.MatchNumber = item.MatchNumber;
                matchesDetail.DateMatch = item.DateMatch;
                matchesDetail.TimeMatch = item.TimeMatch;
                matchesDetail.MatchYear = item.MatchYear;
                matchesDetail.SeasonId = item.SeasonId;
                matchesDetail.SeasonName = item.SeasonName;
                matchesDetail.Round = item.Round;
                matchesDetail.Stage = item.Stage;
                matchesDetail.SubStage = item.SubStage;
                matchesDetail.HTeam = item.HTeam;
                matchesDetail.HGoal = item.HGoal;
                matchesDetail.HTeamCode = item.HTeamCode;
                matchesDetail.GGoal = item.GGoal;
                matchesDetail.GTeam = item.GTeam;
                matchesDetail.GTeamCode = item.GTeamCode;
                matchesDetail.WinNote = item.WinNote;
                matchesDetail.Stadium = item.Stadium;
                matchesDetail.Referee = item.Referee;
                matchesDetail.Visistors = item.Visistors;
                #endregion
                retList.Add(matchesDetail);
            }
            #endregion
            return retList;
        }

        public IEnumerable<MatchesDetailTwoTeam> GetHistoryMatchTwoTeamAsync(string hTeam, string gTeam)
        {
            #region TryOther way
            var matchQuery = (from match in _context.Matches
                              join team1 in _context.Teams on match.HTeam equals team1.TeamName
                              join team2 in _context.Teams on match.GTeam equals team2.TeamName
                              join season in _context.Seasons on match.SeasonId equals season.SeasonId
                              where (match.HTeam == hTeam && match.GTeam==gTeam)||(match.HTeam==gTeam && match.GTeam==hTeam)
                              orderby match.MatchYear descending, match.MatchNumber
                              select new
                              {
                                  #region selectResult
                                  match.MatchId,
                                  match.MatchNumber,
                                  match.DateMatch,
                                  match.TimeMatch,
                                  match.MatchYear,
                                  match.SeasonId,
                                  season.SeasonName,
                                  match.Round,
                                  match.Stage,
                                  match.SubStage,
                                  match.HTeam,
                                  HTeamCode = team1.TeamCode,
                                  match.HGoal,
                                  match.GGoal,
                                  match.GTeam,
                                  GTeamCode = team2.TeamCode,
                                  match.WinNote,
                                  match.Stadium,
                                  match.Referee,
                                  match.Visistors
                                  #endregion
                              });
            List<MatchesDetailTwoTeam> retList = new List<MatchesDetailTwoTeam>();
            foreach (var item in matchQuery)
            {
                MatchesDetailTwoTeam matchesDetail = new MatchesDetailTwoTeam();
                #region ManualMapping
                matchesDetail.MatchId = item.MatchId;
                matchesDetail.MatchNumber = item.MatchNumber;
                matchesDetail.DateMatch = item.DateMatch;
                matchesDetail.TimeMatch = item.TimeMatch;
                matchesDetail.MatchYear = item.MatchYear;
                matchesDetail.SeasonId = item.SeasonId;
                matchesDetail.SeasonName = item.SeasonName;
                matchesDetail.Round = item.Round;
                matchesDetail.Stage = item.Stage;
                matchesDetail.SubStage = item.SubStage;
                matchesDetail.HTeam = item.HTeam;
                matchesDetail.HGoal = item.HGoal;
                matchesDetail.HTeamCode = item.HTeamCode;
                matchesDetail.GGoal = item.GGoal;
                matchesDetail.GTeam = item.GTeam;
                matchesDetail.GTeamCode = item.GTeamCode;
                matchesDetail.WinNote = item.WinNote;
                matchesDetail.Stadium = item.Stadium;
                matchesDetail.Referee = item.Referee;
                matchesDetail.Visistors = item.Visistors;
                #endregion
                retList.Add(matchesDetail);
            }
            #endregion
            return retList;
        }
    }
}
