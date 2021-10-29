using Domain.Entities;
using Infrastructure.Database.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.DatabaseSeeds.SeedEntities
{
    public static class SeedSeasons
    {        
        public static async Task SeedSeasonsDataAsync(ApplicationDbContext context)
        {
            if (context.Seasons.Any())
            {
                return;   // DB has been seeded
            }
            context.Seasons.AddRange
            (
            #region FifaworldCup Seed
                new Season { SeasonId = "FIFAWC2022", TournamentId = "FIFAWC", SeasonName = "World Cup 2022 Quatar", IsFinished = false },
                new Season { SeasonId = "FIFAWC2018", TournamentId = "FIFAWC", SeasonName = "World Cup 2018 Russia", IsFinished = true },
                new Season { SeasonId = "FIFAWC2014", TournamentId = "FIFAWC", SeasonName = "World Cup 2014 Brazil", IsFinished = true },
                new Season { SeasonId = "FIFAWC2010", TournamentId = "FIFAWC", SeasonName = "World Cup 2010 South Africa", IsFinished = true },
                new Season { SeasonId = "FIFAWC2006", TournamentId = "FIFAWC", SeasonName = "World Cup 2006 Germany", IsFinished = true },
                new Season { SeasonId = "FIFAWC2002", TournamentId = "FIFAWC", SeasonName = "World Cup 2002 Korea/Japan", IsFinished = true },
                new Season { SeasonId = "FIFAWC1998", TournamentId = "FIFAWC", SeasonName = "World Cup 1998 France", IsFinished = true },
                new Season { SeasonId = "FIFAWC1994", TournamentId = "FIFAWC", SeasonName = "World Cup 1994 USA", IsFinished = true },
                new Season { SeasonId = "FIFAWC1990", TournamentId = "FIFAWC", SeasonName = "World Cup 1990 Italy", IsFinished = true },
                new Season { SeasonId = "FIFAWC1986", TournamentId = "FIFAWC", SeasonName = "World Cup 1986 Mexico", IsFinished = true },
                new Season { SeasonId = "FIFAWC1982", TournamentId = "FIFAWC", SeasonName = "World Cup 1982 Spain", IsFinished = true },
                new Season { SeasonId = "FIFAWC1978", TournamentId = "FIFAWC", SeasonName = "World Cup 1978 Argentina", IsFinished = true },
                new Season { SeasonId = "FIFAWC1974", TournamentId = "FIFAWC", SeasonName = "World Cup 1974 Germany", IsFinished = true },
                new Season { SeasonId = "FIFAWC1970", TournamentId = "FIFAWC", SeasonName = "World Cup 1970 Mexico", IsFinished = true },
                new Season { SeasonId = "FIFAWC1966", TournamentId = "FIFAWC", SeasonName = "World Cup 1966 England", IsFinished = true },
                new Season { SeasonId = "FIFAWC1962", TournamentId = "FIFAWC", SeasonName = "World Cup 1962 Chile", IsFinished = true },
                new Season { SeasonId = "FIFAWC1958", TournamentId = "FIFAWC", SeasonName = "World Cup 1958 Sweden", IsFinished = true },
                new Season { SeasonId = "FIFAWC1954", TournamentId = "FIFAWC", SeasonName = "World Cup 1954 Switzerland", IsFinished = true },
                new Season { SeasonId = "FIFAWC1950", TournamentId = "FIFAWC", SeasonName = "World Cup 1950 Brazil", IsFinished = true },
                new Season { SeasonId = "FIFAWC1938", TournamentId = "FIFAWC", SeasonName = "World Cup 1938 France", IsFinished = true },
                new Season { SeasonId = "FIFAWC1934", TournamentId = "FIFAWC", SeasonName = "World Cup 1934 Italy", IsFinished = true },
                new Season { SeasonId = "FIFAWC1930", TournamentId = "FIFAWC", SeasonName = "World Cup 1930 Uruguay", IsFinished = true },
            #endregion
            #region FifaEuro Seed
                new Season { SeasonId = "UEFAEURO2020", TournamentId = "UEFAEU", SeasonName = "UEFA Euro 2020", IsFinished = true },
                new Season { SeasonId = "UEFAEURO2016", TournamentId = "UEFAEU", SeasonName = "UEFA Euro 2016 France", IsFinished = true },
                new Season { SeasonId = "UEFAEURO2012", TournamentId = "UEFAEU", SeasonName = "UEFA Euro 2012 Poland and Ukraine", IsFinished = true },
                new Season { SeasonId = "UEFAEURO2008", TournamentId = "UEFAEU", SeasonName = "UEFA Euro 2008 Austria and Switzerland", IsFinished = true }
                #endregion


             );
            context.SaveChanges();
            await context.SaveChangesAsync();
        }
    }
}
