using Application.Interfaces.Contexts;
using Application.Interfaces.Shared;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.DatabaseContext
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        #region Constructor
        private readonly ICurrentUserService _currentUserService;
        public ApplicationDbContext(DbContextOptions options, ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }
        #endregion
        public DbSet<Country> Countries { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamType> TeamTypes { get; set; }
        public DbSet<BettingType> BettingTypes { get; set; }
        public DbSet<Federation> Federations { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            #region Relationship
            builder.Entity<Tournament>().HasOne(f => f.Federations).WithMany(t => t.Tournaments).HasForeignKey(fk => fk.FederationName);            
            builder.Entity<Season>().HasOne(tour => tour.Tournaments).WithMany(s => s.Seasons).HasForeignKey(fk => fk.TournamentId);
            builder.Entity<Team>().HasOne(c => c.Countries).WithMany(t => t.Teams).HasForeignKey(t => t.FifaAlphaCode);
            builder.Entity<Team>().HasOne(t => t.TeamTypes).WithMany(team => team.Teams).HasForeignKey(fk => fk.TypeName);
            builder.Entity<Match>().HasOne(m => m.Seasons).WithMany(se => se.Matches).HasForeignKey(fk => fk.SeasonId);
            builder.Entity<Match>().HasOne(m => m.HomeTeam).WithMany(team => team.HomeMatches).HasForeignKey(fk => fk.HTeam);
            builder.Entity<Match>().HasOne(m => m.GuestTeam).WithMany(team => team.GuestMatches).HasForeignKey(fk => fk.GTeam);
           
            #endregion


            base.OnModelCreating(builder);
        }
    }
}
