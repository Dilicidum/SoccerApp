using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class Team_LeagueConfiguration : IEntityTypeConfiguration<Team_League>
    {
        public void Configure(EntityTypeBuilder<Team_League> builder)
        {
            builder.HasKey(c => new { c.LeagueId, c.TeamId });
            builder.HasOne(c => c.Team)
                .WithMany(c => c.Current_Leagues)
                .HasForeignKey(c => c.TeamId);
            builder.HasOne(c => c.League)
                .WithMany(c => c.Teams)
                .HasForeignKey(c => c.LeagueId);
        }
    }
}
