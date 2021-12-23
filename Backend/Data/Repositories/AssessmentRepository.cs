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

        public IEnumerable<Assessment> SearchByPatientId(int query)
        {
            try
            {
                var result = base.GetAll()
                    .First(i => i.PatientId.Equals(query));

                return result;
            }
            catch (System.Exception)
            {

                throw new KeyNotFoundException("No result found");
            }



        }
    }
}