using Domain.Entities;
using Infrastructure.Database.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.DatabaseSeeds.SeedEntities
{
    public static class SeedTeamTypes
    {        
        public static async Task SeedTeamTypesDataAsync(ApplicationDbContext context)
        {
            
            if (context.TeamTypes.Any())
            {
                return;   // DB has been seeded
            }
            context.TeamTypes.AddRange(
                new TeamType { TypeName="National" },
                new TeamType { TypeName = "Club" }
             ) ;
            context.SaveChanges();
            await context.SaveChangesAsync();
        }
    }
}
