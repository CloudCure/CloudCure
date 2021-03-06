using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Diagnosis;

namespace Data
{
    public interface ISurgeryRepository : IRepository<Surgery>
    {
        IEnumerable<Surgery> SearchByPatientId(int query);
    }
}