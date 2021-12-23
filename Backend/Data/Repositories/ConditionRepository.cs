using System.Collections.Generic;
using System.Linq;
using Models.Diagnosis;

namespace Data
{

    public class ConditionRepository : Repository<Condition>, IConditionRepository
    {
        public ConditionRepository(CloudCureDbContext context) : base(context)
        {
        }

        public IEnumerable<Condition> SearchByCondition(string query)
        {
            var Condition = GetAll().Where(b => b.ConditionName.Equals(query));
            if (!Condition.Any())
            {
                throw new KeyNotFoundException("Condition not found.");
            }
            else
            {
                return Condition;
            }
        }

        public IEnumerable<Condition> SearchByPatientId(int query)
        {
            var result = base.GetAll()
                        .Where(i => i.PatientId.Equals(query));
            if (!result.Any())
            {
                throw new KeyNotFoundException("No result found");
            }

            return result;
        }
    }
}