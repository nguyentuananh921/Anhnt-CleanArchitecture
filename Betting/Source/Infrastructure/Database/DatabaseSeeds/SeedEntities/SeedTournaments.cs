using Domain.Entities;
using Infrastructure.Database.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.DatabaseSeeds.SeedEntities
{
    public static class SeedTournaments
    {        
        public static async Task SeedTournamentsDataAsync(ApplicationDbContext context)
        {
            if (context.Tournaments.Any())
            {
                return;   // DB has been seeded
            }
            context.Tournaments.AddRange(
                new Tournament { TournamentId = "FIFAWC",TourName="FIFA World Cup",FederationName="FIFA",IsActive=true },
                new Tournament { TournamentId = "UEFAEU", TourName = "UEFA Euro", FederationName = "UEFA", IsActive = true }
             );
            context.SaveChanges();
            await context.SaveChangesAsync();
        }
    }
}
