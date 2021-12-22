using System.Collections.Generic;
using Models.Diagnosis;

namespace Data
{
     public interface IDiagnosisRepository
    {
        IEnumerable<Diagnosis> GetAllDiagnosisByPatientIdWithNav(int query);
        Diagnosis GetByPatientIdWithNav(int query);
    }

}