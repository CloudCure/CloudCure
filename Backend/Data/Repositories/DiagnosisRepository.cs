using Models.Diagnosis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var patient = repository.Diagnoses
               .Include(p => p.Vitals)
               .Include(p => p.Patient)
               .Include(c => c.Patient.Allergies)
                .Include(c => c.Patient.Conditions)
                .Include(c => c.Patient.Surgeries)
                .Include(c => c.Patient.CurrentMedications)
               .Include(p => p.Assessment)               
               .Single(p => p.Patient.Id.Equals(query));

            return patient;
          
        }
    }
}