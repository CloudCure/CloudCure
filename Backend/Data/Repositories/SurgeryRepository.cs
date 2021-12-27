using System.Collections.Generic;
using System.Linq;
using Models.Diagnosis;

namespace Data
{
    public class SurgeryRepository : Repository<Surgery>, ISurgeryRepository
    {
        public SurgeryRepository(CloudCureDbContext context) : base(context)
        {
        }

        public IEnumerable<Surgery> SearchByPatientId(int query)
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