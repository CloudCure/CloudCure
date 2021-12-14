using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
                 return repository.Employee
                 .Include(e => e.UserProfile)
                 .ThenInclude(u => u.Role)
                 .Single(e => e.Id.Equals(p_id));
            }
            catch (System.Exception)
            {
                
                throw new KeyNotFoundException("Employee Id Not Found!");
            }
        }
    }
}