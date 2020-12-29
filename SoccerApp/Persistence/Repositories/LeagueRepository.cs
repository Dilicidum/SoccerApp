using Application.Interfaces.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace Persistence.Repositories
{
    public class LeagueRepository:Repository<League>,ILeagueRepository
    {
        public ApplicationDbContext Context
        {
            get { return context; }
        }

        public DbSet<League> dbSet { get; }

        public LeagueRepository(ApplicationDbContext context) : base(context) { dbSet = context.Set<League>(); }
    }
}
