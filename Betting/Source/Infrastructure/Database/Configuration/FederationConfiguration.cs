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
    public class FederationConfiguration : IEntityTypeConfiguration<Federation>
    {        
        public void Configure(EntityTypeBuilder<Federation> builder)
        {
            builder.HasKey(t => t.FName);
            builder.Property(t => t.FName)
                .HasMaxLength(20)
                .IsRequired();
        }
    }    
}
