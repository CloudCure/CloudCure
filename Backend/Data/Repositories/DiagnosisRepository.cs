using Models.Diagnosis;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Data
{


    public class DiagnosisRepository : Repository<Diagnosis>, IDiagnosisRepository
    {
        readonly CloudCureDbContext repository;
        public DiagnosisRepository(CloudCureDbContext context) : base(context)
        {
            repository = context;
        }

        public Diagnosis GetByPatientIdWithNav(int query)
        {
            var diagnosis = repository.Diagnoses
            .Include(d => d.Vitals)
            .Include(d => d.Assessment)
                .Single(d => d.PatientId.Equals(query));

            return diagnosis;

        }

        public IEnumerable<Diagnosis> GetAllDiagnosisByPatientIdWithNav(int query)
        {
            var diagnoses = repository.Diagnoses
                .Include(d => d.Vitals)
                .Include(d => d.Assessment)
               .Where(p => p.PatientId.Equals(query));

            return diagnoses;

        }
    }
}