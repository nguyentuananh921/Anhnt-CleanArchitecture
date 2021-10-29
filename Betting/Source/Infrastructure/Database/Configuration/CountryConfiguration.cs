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
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {            
            builder.HasKey(t => t.FifaAlphaCode);
            builder.Property(t => t.FifaAlphaCode)
                .HasMaxLength(3)
                .IsRequired();           
            builder.Property(t => t.CountryName)
                .HasMaxLength(50)
                .IsRequired();           

        }
    }
}
