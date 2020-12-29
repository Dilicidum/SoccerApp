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
    public class GameRepository:Repository<Game>,IGameRepository
    {
        public ApplicationDbContext Context
        {
            get { return context; }
        }

        public DbSet<Game> dbSet { get; }

        public GameRepository(ApplicationDbContext context) : base(context) { dbSet = context.Set<Game>(); }

        public async Task<IEnumerable<Game>> GetGamesWithDetails(Expression<Func<Game, bool>> filter = null)
        {
            IQueryable<Game> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.Include(c => c.House_Team).ThenInclude(c=>c.Players)
                .Include(c=>c.Guest_Team).ThenInclude(c=>c.Players).Include(c=>c.League)
                .Include(c=>c.Stadium).ToListAsync();
        }
    }
}
