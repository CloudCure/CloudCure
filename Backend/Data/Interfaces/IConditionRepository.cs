using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Diagnosis;

namespace Data
{
    public interface IConditionRepository : IRepository<Condition>
    {
        //Condition SearchByPatientId(int query);
        IEnumerable<Condition> SearchByPatientId(int query);
        IEnumerable<Condition> SearchByCondition(string query);
    }
}