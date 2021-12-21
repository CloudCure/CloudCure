using System.Collections.Generic;
using Models;

namespace Data
{
    public interface IEmployeeInformationRepository : IRepository<EmployeeInformation>
    {

        /// <summary>
        /// Searches the repository for an EmployeeInformation object based on 
        /// user ID.
        /// </summary>
        /// <param name="p_id">User ID</param>
        /// <returns>EmployeeInformation object | throws KeyNotFoundException if user ID is not found</returns>
        EmployeeInformation GetEmployeeInformationById(int p_id);

        ///todo
        List<EmployeeInformation> GetAllEmployee();

        /// <summary>
        /// Will check our database if there is an employee with an email matching p_email 
        /// and will return the result if found.
        /// </summary>
        /// <param name="p_email">The email that will be searched with</param>
        /// <returns>The Employee found</returns>
        EmployeeInformation VerifyEmail(string p_email);

    }
}