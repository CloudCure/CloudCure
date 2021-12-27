using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Diagnosis;

//Grouping of classes for data access functionality
namespace Data
{
    //Inherits methods from Repository repo and Assessment Repository Interface
    public class AssessmentRepository : Repository<Assessment>, IAssessmentRepository
    {
        //Constructor sets AssessmentRepository class with DbContext class for database access
        public AssessmentRepository(CloudCureDbContext context) : base(context)
        {
        }

        //Returns list of all diagnoses containing user requested Diagnosis Id
        public IEnumerable<Assessment> SearchByDiagnosisId(int query)
        {
            var result = base.GetAll()
                .Where(i => i.DiagnosisId.Equals(query));
            return result;
        }
    }
}