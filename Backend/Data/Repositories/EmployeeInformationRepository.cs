using Models;

namespace Data
{
    public class EmployeeInformationRepository : Repository<EmployeeInformation>, IEmployeeInformationRepository
    {
        readonly CloudCureDbContext repository;

        public EmployeeInformationRepository(CloudCureDbContext context) : base(context)
        {
            repository = context;
        }
    }
}