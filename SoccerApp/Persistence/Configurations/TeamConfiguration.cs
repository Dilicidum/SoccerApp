using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(k => k.TeamId);
            builder.HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId);

            builder.HasMany(t => t.Current_Leagues)
                .WithOne(l => l.Team)
                .HasForeignKey(l => l.TeamId);
        }
    }
}
