using Models;

namespace Data
{
    public interface IEmployeeInformationRepository : IRepository<EmployeeInformation>
    {
        EmployeeInformation VerifyEmail(string p_email);
    }
}