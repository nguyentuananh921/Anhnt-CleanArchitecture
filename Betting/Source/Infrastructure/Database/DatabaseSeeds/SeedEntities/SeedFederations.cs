using Domain.Entities;
using Infrastructure.Database.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.DatabaseSeeds.SeedEntities
{
    public static class SeedFederations
    {        
        public static async Task SeedFederationsDataAsync(ApplicationDbContext context)
        {
            if (context.Federations.Any())
            {
                return;   // DB has been seeded
            }
            context.Federations.AddRange(
                new Federation { FName = "FIFA" },
                new Federation { FName = "UEFA" },                
                new Federation { FName = "AFC" }
             );
            context.SaveChanges();
            await context.SaveChangesAsync();
        }
    }
}
