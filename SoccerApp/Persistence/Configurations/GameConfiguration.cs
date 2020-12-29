using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {

        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(k => k.GameId);
            builder.Property(prop => prop.GameResult).HasConversion<string>();
            
            builder.HasOne(g => g.Guest_Team)
                .WithMany(t => t.Guest_Games)
                .HasForeignKey(g => g.Guest_Team_Id);

            builder.HasOne(g => g.House_Team)
                .WithMany(t => t.Home_Games)
                .HasForeignKey(g => g.House_Team_Id)
                .OnDelete(DeleteBehavior.NoAction)
                .HasPrincipalKey(t=>t.TeamId);


            builder.HasOne(g => g.Stadium)
                .WithMany(s=>s.Games)
                .HasForeignKey(g => g.Stadium_Id);

            builder.HasOne(g => g.League)
                .WithMany(l => l.Games)
                .HasForeignKey(g => g.LeagueId);
        }
    }
}
