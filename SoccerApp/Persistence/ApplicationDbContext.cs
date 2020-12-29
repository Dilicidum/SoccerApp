using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain.Entities;
using Persistence.Configurations;
using Application.Interfaces.Persistence;
namespace Persistence
{
    public class ApplicationDbContext:IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<CCountry> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Team_League> Team_Leagues { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<CCountry>(new CountryConfiguration());
            modelBuilder.ApplyConfiguration<Game>(new GameConfiguration());
            modelBuilder.ApplyConfiguration<League>(new LeagueConfiguration());
            modelBuilder.ApplyConfiguration<Player>(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration<Stadium>(new StadiumConfiguration());
            modelBuilder.ApplyConfiguration<Team>(new TeamConfiguration());
            modelBuilder.ApplyConfiguration<Team_League>(new Team_LeagueConfiguration());
            //modelBuilder.ApplyConfiguration(new Game_PlayerConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
