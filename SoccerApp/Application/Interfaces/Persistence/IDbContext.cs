using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Application.Interfaces.Persistence
{
    public interface IDbContext
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
