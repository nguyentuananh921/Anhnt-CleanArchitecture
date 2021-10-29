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
    public class BettingTypeConfiguration : IEntityTypeConfiguration<BettingType>
    {
        public void Configure(EntityTypeBuilder<BettingType> builder)
        {            
            builder.HasKey(t => t.strID);
            builder.Property(t => t.strID)
                .HasMaxLength(3)
                .IsRequired();
            builder.Property(t => t.vName)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(t => t.eName)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(t => t.vDescription)
                .HasMaxLength(50)
                .IsRequired();

        }
    }
}
