using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class LeagueConfiguration : IEntityTypeConfiguration<League>
    {
        public void Configure(EntityTypeBuilder<League> builder)
        {
            builder.HasKey(prop => prop.LigueId);
            builder.HasMany(l => l.Countries)
                .WithOne();

            builder.HasMany(p => p.Games)
                 .WithOne(g => g.League)
                 .HasForeignKey(c=>c.LeagueId);
            
            
        }
    }
}
