using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Diagnosis;

namespace Data
{
    public interface IAssessmentRepository : IRepository<Assessment>
    {
          IEnumerable<Assessment> SearchByPatientId(int query);
    }
}