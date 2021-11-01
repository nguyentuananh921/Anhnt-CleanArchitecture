using Application.Features.Matches.Queries;
using Application.Interfaces.Repositories.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IMatchRepository:IGenericRepository<Match>
    {        
        IEnumerable<MatchesDetail> GetMatchDetailAsync();
        IEnumerable<MatchesDetailByTeamName> GetMatchDetailByTeamNameAsync(string teamname);
        IEnumerable<MatchesDetailBySeason> GetMatchDetailBySeasonAsync(string seasonname);
        IEnumerable<MatchesDetailTwoTeam> GetHistoryMatchTwoTeamAsync(string hTeam, string gTeam);
        MatchesDetailByStrId GetMatchDetailByMatchStrId(string matchid); //This match contain more information than Match entity
    }
}
