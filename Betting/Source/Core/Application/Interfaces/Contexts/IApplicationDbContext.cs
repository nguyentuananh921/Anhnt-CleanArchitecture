using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Contexts
{
    public interface IApplicationDbContext
    {
        DbSet<Country> Countries { get; set; }
        DbSet<Team> Teams { get; set; }
        DbSet<TeamType> TeamTypes { get; set; }
        DbSet<BettingType> BettingTypes { get; set; }
        DbSet<Federation> Federations { get; set; }
        DbSet<Tournament> Tournaments { get; set; }
        DbSet<Season> Seasons { get; set; }
        DbSet<Match> Matches { get; set; }        

    }
    
}
