using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Diagnosis;

namespace Data
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Patient GetbyPatientWithNav(int query);
        IEnumerable<Patient> GetAllWithNav();
    }
}