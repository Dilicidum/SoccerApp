using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using System.Threading.Tasks;
using System.Linq.Expressions;
namespace Application.Interfaces.Persistence
{
    public interface ITeamRepository:IRepository<Team>
    {
        public Task<IEnumerable<Team>> GetTeamsWithDetails(Expression<Func<Team, bool>> filter = null);
    }
}
