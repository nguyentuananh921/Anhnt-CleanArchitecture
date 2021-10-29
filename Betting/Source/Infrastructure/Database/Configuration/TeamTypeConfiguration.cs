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
    public class TeamTypeConfiguration : IEntityTypeConfiguration<TeamType>
    {
        public void Configure(EntityTypeBuilder<TeamType> builder)
        {            
            builder.HasKey(t => t.TypeName);
            builder.Property(t => t.TypeName)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
