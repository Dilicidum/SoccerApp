using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;

namespace Application.Interfaces.Persistence
{
    public interface IStadiumRepository:IRepository<Stadium>
    {
        Task<Stadium> GetStadiumByIdWithDetails(int stadiumId);
    }
}
