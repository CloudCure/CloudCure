using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Diagnosis;

namespace Data
{
    public class VitalsRepository : Repository<Vitals>, IVitalsRepository
    {
        public VitalsRepository(CloudCureDbContext context) : base(context)
        {
        }

        public Vitals SearchByPatientId(int p_patientId)
        {
            try
            {
            var result = base.GetAll()
                        .FirstOrDefault(vital => vital.PatientId == p_patientId);
            return result;
            }
            catch (System.Exception)
            {
                
                throw new KeyNotFoundException("No Vitals Found");
            }
        }
    }
}