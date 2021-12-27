using Models;

//Grouping of classes for data access functionality
namespace Data
{
    //Inherits methods from Repository repo and Role Repository interface
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        //Constructor sets RoleRepository class with DbContext class for database access
        public RoleRepository(CloudCureDbContext context) : base(context)
        {
        }
    }
}