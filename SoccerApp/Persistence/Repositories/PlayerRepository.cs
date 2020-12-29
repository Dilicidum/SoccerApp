using Application.Interfaces.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;

namespace Persistence.Repositories
{
    public class PlayerRepository:Repository<Player>,IPlayerRepository
    {
        public ApplicationDbContext Context
        {
            get { return context; }
        }

        public DbSet<Player> dbSet { get; }

        public PlayerRepository(ApplicationDbContext context) : base(context) { dbSet = context.Set<Player>(); }

        public async Task<IEnumerable<Player>> GetPlayersWithDetails(Expression<Func<Player, bool>> filter = null)
        {
            IQueryable<Player> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.Include(c => c.Team).ToListAsync();
        }
    }
}
