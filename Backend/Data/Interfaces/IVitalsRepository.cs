using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Diagnosis;

namespace Data
{
    public interface IVitalsRepository : IRepository<Vitals>
    {
        Vitals SearchByPatientId(int p_patientId);
    }
}