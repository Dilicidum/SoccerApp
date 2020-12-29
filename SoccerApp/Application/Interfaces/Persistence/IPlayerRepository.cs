using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Domain.Entities;
using System.Threading.Tasks;
namespace Application.Interfaces.Persistence
{
    public interface IPlayerRepository:IRepository<Player>
    {
        public Task<IEnumerable<Player>> GetPlayersWithDetails(Expression<Func<Player, bool>> filter = null);
    }
}
