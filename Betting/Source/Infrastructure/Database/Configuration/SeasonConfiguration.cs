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
    public class SeasonConfiguration : IEntityTypeConfiguration<Season>
    {
        public void Configure(EntityTypeBuilder<Season> builder)
        {            
            builder.HasKey(t => t.SeasonId);
            builder.Property(t => t.SeasonId)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(t => t.SeasonName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(t => t.TournamentId)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
