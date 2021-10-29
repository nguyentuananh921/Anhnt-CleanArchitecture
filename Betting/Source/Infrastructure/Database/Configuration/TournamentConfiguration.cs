using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Configuration
{
    public class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {            
            builder.HasKey(t => t.TournamentId);
            builder.Property(t => t.TournamentId)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(t => t.TourName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(t => t.FederationName)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
