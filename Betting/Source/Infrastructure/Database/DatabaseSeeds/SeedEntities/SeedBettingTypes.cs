using Domain.Entities;
using Infrastructure.Database.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.DatabaseSeeds.SeedEntities
{
    public static class SeedBettingTypes
    {        
        public static async Task SeedBettingTypesDataAsync(ApplicationDbContext context)
        {
            
            if (context.BettingTypes.Any())
            {
                return;   // DB has been seeded
            }
            context.BettingTypes.AddRange(
                new BettingType { strID="A",vName="Thắng thua",eName= "Fulltime",vDescription= "Chỉ tính hai hiệp chính" },
                new BettingType { strID = "B", vName = "Cược chấp", eName = "Asian Handicap", vDescription = "Chỉ tính hai hiệp chính" },
                new BettingType { strID = "C", vName = "Tài xỉu", eName = "Goal Line", vDescription = "Chỉ tính hai hiệp chính" },
                new BettingType { strID = "D", vName = "Tỉ số", eName = "Correct Score", vDescription = "Chỉ tính hai hiệp chính" },
                new BettingType { strID = "E", vName = "Vào vòng trong", eName = "Qualify", vDescription = "Tính toàn trận" },
                new BettingType { strID = "F", vName = "Đội vô địch", eName = "Win Outright", vDescription = "Tính đến cuối giải" },
                new BettingType { strID = "G", vName = "Trừ tiền", eName = "Punish", vDescription = "Trừ tiền" },
                new BettingType { strID = "H", vName = "Tặng tiền", eName = "Award", vDescription = "Tặng tiền" }
             );
            context.SaveChanges();
            await context.SaveChangesAsync();
        }
    }
}
