using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
namespace Application.Interfaces.Persistence
{
    public interface IGameRepository:IRepository<Game>
    {
        public Task<IEnumerable<Game>> GetGamesWithDetails(Expression<Func<Game, bool>> filter = null);
    }
}
