using Application.Interfaces.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace Persistence.Repositories
{
    public class StadiumRepository:Repository<Stadium>,IStadiumRepository
    {
        public ApplicationDbContext Context
        {
            get { return context; }
        }

        public DbSet<Stadium> dbSet { get; }

        public StadiumRepository(ApplicationDbContext context) : base(context) { dbSet = context.Set<Stadium>(); }

        public async Task<Stadium> GetStadiumByIdWithDetails(int stadiumId)
        {
            return await dbSet.Where(c => c.StadiumId == stadiumId)
                .Include(c => c.Games).ThenInclude(c => c.Guest_Team)
                .Include(c => c.Games).ThenInclude(c => c.House_Team).FirstOrDefaultAsync();
        }
    }
}
