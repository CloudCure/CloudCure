using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

//Grouping of classes for data access functionality
namespace Data
{
    //Inherits methods from Repository repo and User Repository interface
    public class UserRepository : Repository<User>, IUserRepository
    {
        //User repository can only be defined in its Constructor
        readonly CloudCureDbContext repository;

        //Costructors sets UserRepository class with DbContext class for database access
        public UserRepository(CloudCureDbContext context) : base(context)
        {
            repository = context;
        }

        
        /// <summary>
        /// Retrives information on user based on the user id
        /// </summary>
        /// <param name="p_id">query which will be Id</param>
        public User GetUserById(int p_id)
        {
            try
            {
                return repository.Users
                .Include(r => r.Role)
                .Include(c => c.CovidAssesments)
                .Single(e => e.Id.Equals(p_id));
            }
            
            //Exeption will be thrown if user id is out of range
            catch (System.Exception)
            {
                throw new KeyNotFoundException("Employee Id Not Found!");
            }
        }
    }
}