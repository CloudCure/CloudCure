using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

//Grouping of classes for data access functionality
namespace Data
{
    //Inherits methods from Repository repo and Employee Information Repository interface
    public class EmployeeInformationRepository : Repository<EmployeeInformation>, IEmployeeInformationRepository
    {
        //Employee Infromtation repository can only be defined in its Constructor
        readonly CloudCureDbContext repository;

        //Constructor sets EmployeeInformationRepository class with DbContext class for database access
        public EmployeeInformationRepository(CloudCureDbContext context) : base(context)
        {
            repository = context;
        }

        //Retrieves Employee details containing user requested Id
        public EmployeeInformation GetEmployeeInformationById(int p_id)
        {
            try
            {
                //Employee Information contains CovidAssessment and Role information for that employee
                return repository.Employee
                .Include(e => e.UserProfile)
                .ThenInclude(c => c.CovidAssesments)
                .Include(e => e.UserProfile)
                .ThenInclude(u => u.Role)
                .Single(e => e.Id.Equals(p_id));
            }
            
            //Returns exception if requested Employee Id cannot be found in the database
            catch (System.Exception)
            {
                throw new KeyNotFoundException("Employee Id Not Found!");
            }
        }

        //Retrieves list of all employee details pertaining to each employee in the database
        public List<EmployeeInformation> GetAllEmployee()
        {
            try
            {
                //Each employee has CovidAssessment and Role information
                return repository.Employee
                .Include(e => e.UserProfile)
                .ThenInclude(c => c.CovidAssesments)
                .Include(e => e.UserProfile)
                .ThenInclude(u => u.Role)
                .ToList();
            }
            
            //Returns an exception if the GetAllEmployee method failed to execute
            catch (System.Exception)
            {
                throw new KeyNotFoundException("Get all failed on employee info!");
            }
        }

        public EmployeeInformation VerifyEmail(string p_email)
        {
            try
            {
                return repository.Employee
                    .Include(e => e.UserProfile)
                    .ThenInclude(u => u.Role)
                    .FirstOrDefault(emp => emp.WorkEmail == p_email);
            }
            catch (System.Exception)
            {
                throw new KeyNotFoundException("No Employee found with the email ");
            }
        }
    }
}