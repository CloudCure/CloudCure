using System.Collections.Generic;
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

        public EmployeeInformation GetEmployeeInformationById(int p_id)
        {
            try
            {
                 return GetByPrimaryKey(p_id);
            }
            catch (System.Exception)
            {
                
                throw new KeyNotFoundException("Employee Id Not Found!");
            }
        }
    }
}