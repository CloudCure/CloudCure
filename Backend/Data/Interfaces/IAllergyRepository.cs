using System.Collections.Generic;
using Models.Diagnosis;

namespace Data
{
    public interface IAllergyRepository : IRepository<Allergy>
    {
    Allergy SearchByPatientId(int query);

       IEnumerable<Allergy> SearchByAllergy(string query);
    }
}