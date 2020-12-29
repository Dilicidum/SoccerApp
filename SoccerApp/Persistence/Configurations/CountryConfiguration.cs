using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<CCountry>
    {
        public void Configure(EntityTypeBuilder<CCountry> builder)
        {
            builder.HasKey(prop => prop.CountryId);
            builder.Property(prop => prop.Country).HasConversion<string>();
        }
    }
}
