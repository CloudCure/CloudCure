using System.Collections.Generic;

namespace Data
{
    public interface IAllergyRepository : IRepository<AllergyRepository>
    {
        IEnumerable<AllergyRepository> SearchByPatientId(int query);
    }
}