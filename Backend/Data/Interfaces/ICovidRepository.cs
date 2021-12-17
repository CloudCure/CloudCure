using System.Collections.Generic;
using Models;

namespace Data
{
    public interface ICovidRepository : IRepository<CovidVerify>
    {
        CovidVerify GetCovidInfoForUser(int p_Id);
    }
}