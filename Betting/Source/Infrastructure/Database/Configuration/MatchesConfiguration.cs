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
    public class MatchesConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {            
            builder.HasKey(t => t.MatchId);
            builder.Property(t => t.DateMatch).HasColumnType("date");
            builder.Property(t => t.TimeMatch).HasColumnType("time");
            builder.Property(t => t.MatchId)
                .HasMaxLength(20)
                .IsRequired();            
        }
    }
}
