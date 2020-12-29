using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class StadiumConfiguration : IEntityTypeConfiguration<Stadium>
    {
        public void Configure(EntityTypeBuilder<Stadium> builder)
        {
            builder.HasKey(prop => prop.StadiumId);
            builder.HasMany(s => s.Games)
                .WithOne(g => g.Stadium)
                .HasForeignKey(g => g.Stadium_Id);


        }
    }
}
