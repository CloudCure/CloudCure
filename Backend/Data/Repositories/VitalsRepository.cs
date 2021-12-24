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

        public Vitals SearchByDiagnosisId(int p_patientId)
        {
            try
            {
            var result = base.GetAll()
                        .FirstOrDefault(vital => vital.DiagnosisId == p_patientId);
            return result;
            }
            catch (System.Exception)
            {
                
                throw new KeyNotFoundException("No Vitals Found");
            }
        }
    }
}