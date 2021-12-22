using Models;

namespace Data
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(CloudCureDbContext context) : base(context)
        {
        }
    }
}