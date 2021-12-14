using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Will check our database if there is an employee with an email matching p_email 
        /// and will return the result if found.
        /// </summary>
        /// <param name="p_email">The email that will be searched with</param>
        /// <returns>The Employee found</returns>
        public EmployeeInformation VerifyEmail(string p_email)
        {
            try
            {
                return repository.Employee
                            .FirstOrDefault(emp => emp.WorkEmail == p_email);
            }
            catch (System.Exception)
            {
                throw new KeyNotFoundException("No Employee found with the email ");
            }
            
        }
    }
}