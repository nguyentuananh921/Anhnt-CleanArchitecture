using Infrastructure.Database.DatabaseContext;
using Infrastructure.Database.DatabaseSeeds.SeedEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.DatabaseSeeds
{
    public static class SeedData
    {

       
        public static async Task SeedAppLicationData(ApplicationDbContext context)
        {
            await SeedCountries.SeedCountriesDataAsync(context);
            await SeedTeamTypes.SeedTeamTypesDataAsync(context);
            await SeedTeams.SeedTeamsDataAsync(context);
            await SeedBettingTypes.SeedBettingTypesDataAsync(context);
            await SeedFederations.SeedFederationsDataAsync(context);
            await SeedTournaments.SeedTournamentsDataAsync(context);
            await SeedSeasons.SeedSeasonsDataAsync(context);
            await SeedTeams.SeedTeamsDataAsync(context);
            await SeedMatches.SeedMatchesDataAsync(context);
            
        }
    }
}
