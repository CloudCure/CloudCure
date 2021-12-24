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
                .Single(d => d.Patient.Id.Equals(query));

            return diagnosis;

        }

        public IEnumerable<Diagnosis> GetAllDiagnosisByPatientIdWithNav(int query)
        {
            var diagnoses = repository.Diagnoses
                .Include(d => d.Vitals)
                .Include(d => d.Assessment)
               .Where(p => p.Patient.Id.Equals(query));

            return diagnoses;
        }
    }
}