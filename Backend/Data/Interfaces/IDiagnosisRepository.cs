using System.Collections.Generic;
using Models.Diagnosis;

namespace Data
{
     public interface IDiagnosisRepository: IRepository<Diagnosis>
    {
        IEnumerable<Diagnosis> GetAllDiagnosisByPatientIdWithNav(int query);
        Diagnosis GetByPatientIdWithNav(int query);
    }

}