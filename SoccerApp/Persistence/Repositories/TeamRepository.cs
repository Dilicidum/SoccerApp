using Application.Interfaces.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;
namespace Persistence.Repositories
{
    public class TeamRepository:Repository<Team>,ITeamRepository
    {
        public ApplicationDbContext Context
        {
            get { return context; }
        }

        public DbSet<Team> dbSet { get; }

        public TeamRepository(ApplicationDbContext context) : base(context) { dbSet = context.Set<Team>(); }
        public async Task<IEnumerable<Team>> GetTeamsWithDetails(Expression<Func<Team, bool>> filter = null)
        {
            IQueryable<Team> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.Include(c => c.Guest_Games).Include(c=>c.Home_Games).ToListAsync();
        }
    }
}
