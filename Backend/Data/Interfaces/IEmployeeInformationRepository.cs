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
        /// <returns>EmployeeInformation object | throws KeyNotFoundException if user ID is not fount</returns>
        EmployeeInformation GetEmployeeInformationById(int p_id);
    }
}