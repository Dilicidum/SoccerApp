using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class PlayerConfiguration:IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(prop => prop.PlayerId);
            builder.Property(prop => prop.Position)
                .HasConversion<string>();
            builder.HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId);
            builder.HasOne(p => p.Country)
                .WithMany()
                .HasForeignKey(c => c.CountryId);
        }
    }
}
