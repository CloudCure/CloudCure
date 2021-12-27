using System.Collections.Generic;
using System.Linq;
using Models.Diagnosis;

//Grouping of classes for data access functionality
namespace Data
{

    //Inherits methods from Repository repo and Condition Repository interface
    public class ConditionRepository : Repository<Condition>, IConditionRepository
    {
        //Constructor sets ConditionRepository class with DbContext class for database access
        public ConditionRepository(CloudCureDbContext context) : base(context)
        {
        }

        //Returns list of all conditions containing user requested Condition Name
        public IEnumerable<Condition> SearchByCondition(string query)
        {
            var Condition = GetAll().Where(b => b.ConditionName.Equals(query));

            //Returns Exception if user requested Condition Name not found in the database
            if (!Condition.Any())
            {
                throw new KeyNotFoundException("Condition not found.");
            }

            //Returns Condition object containing user requested condition name if found in the database
            else
            {
                return Condition;
            }
        }

        //Returns list of Conditions associated with user requested Patient Id
        public IEnumerable<Condition> SearchByPatientId(int query)
        {
            var result = base.GetAll()
                        .Where(i => i.PatientId.Equals(query));
            
            //Returns exception if no Condition containing user requested Patient Id is found in the database
            if (!result.Any())
            {
                throw new KeyNotFoundException("No result found");
            }

            return result;
        }
    }
}