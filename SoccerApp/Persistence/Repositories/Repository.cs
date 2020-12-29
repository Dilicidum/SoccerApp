using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext context;
        private DbSet<TEntity> dbSet;
        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            dbSet = this.context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderby = null, string includingProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includingProperties != null)
            {
                foreach (var includeProperty in includingProperties.Split(new char[] { ',' }
                , StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderby != null)
            {
                return (await orderby(query).ToListAsync());
            }
            else
            {
                return await query.ToListAsync();
            }

        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
