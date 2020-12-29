using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Application.Interfaces.Persistence;

namespace Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ApplicationDbContext Context
        {
            get { return context as ApplicationDbContext; }
        }
        public DbSet<User> dbSet { get; }
        public UserRepository(ApplicationDbContext context) : base(context) { dbSet = Context.Set<User>(); }

        public async Task<User> GetUserByEmail(string email)
        {
            var User = await (dbSet.Where(c => c.Email == email).FirstOrDefaultAsync());
            return User;
        }

        

        public async Task<User> GetFullInfo(string UserId)
        {
            var user = await dbSet.Where(c => c.Id == UserId).FirstOrDefaultAsync();
            return user;
        }

        public async Task ChangeFirstName(string FirstName, User user)
        {
            user.FirstName = FirstName;
            dbSet.Update(user);
        }

        public async Task ChangeLastname(string LastName, User user)
        {
            user.LastName = LastName;
            dbSet.Update(user);
        }

        public async Task ChangeUsername(string UserName, User user)
        {
            user.UserName = UserName;
            user.NormalizedUserName = UserName;
            user.NormalizedUserName.ToUpper();
            dbSet.Update(user);
        }

        public async Task ChangeLastTimeActivity(User user)
        {
            user.DateOfLastActivity = DateTime.Now;
            dbSet.Update(user);
        }
    }
}
