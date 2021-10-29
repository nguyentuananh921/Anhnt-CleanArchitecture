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
    public class TeamsConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {            
            builder.HasKey(t => t.TeamName);            
            builder.Property(t => t.TeamName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(t => t.TeamCode)
                .HasMaxLength(10)
                .IsRequired();
            builder.Property(t => t.FifaAlphaCode)
                .HasMaxLength(3)
                .IsRequired();                       
        }
    }
}
