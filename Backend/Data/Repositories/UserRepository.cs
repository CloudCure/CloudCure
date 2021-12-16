using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        readonly CloudCureDbContext repository;
        public UserRepository(CloudCureDbContext context) : base(context)
        {
            repository = context;
        }

        public User GetUserById(int p_id)
        {
            try
            {
                return repository.Users
                .Include(r => r.Role)
                .Include(c => c.CovidAssesments)
                .Single(e => e.Id.Equals(p_id));
            }
            catch (System.Exception)
            {
                throw new KeyNotFoundException("Employee Id Not Found!");
            }
        }
    }
}