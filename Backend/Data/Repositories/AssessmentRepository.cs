using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Diagnosis;

namespace Data
{
    public class AssessmentRepository : Repository<Assessment>, IAssessmentRepository
    {
        public AssessmentRepository(CloudCureDbContext context) : base(context)
        {
        }

        public IEnumerable<Assessment> SearchByDiagnosisId(int query)
        {
            var result = base.GetAll()
                .Where(i => i.DiagnosisId.Equals(query));
            return result;
        }
    }
}