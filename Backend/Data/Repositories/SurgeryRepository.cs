using System.Collections.Generic;
using System.Linq;
using Models.Diagnosis;

namespace Data
{
    public class SurgeryRepository : Repository<Surgery>, ISurgeryRepository
    {
        readonly CloudCureDbContext repository;
        public SurgeryRepository(CloudCureDbContext context) : base(context)
        {
            repository = context;
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