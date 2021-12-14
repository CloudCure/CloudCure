using Models;

namespace Data
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        readonly CloudCureDbContext repository;
        public RoleRepository(CloudCureDbContext context) : base(context)
        {
            repository = context;
        }
    }
}