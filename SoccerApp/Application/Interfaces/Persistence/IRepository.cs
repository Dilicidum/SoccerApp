using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace Application.Interfaces.Persistence
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entityToUpdate);
    }
}
