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
            var patient = repository.Diagnoses
                .Include(p => p.Vitals)
                .Include(p => p.Patient)
                .Include(p => p.Patient.UserProfile)
                .Include(c => c.Patient.Allergies)
                .Include(c => c.Patient.Conditions)
                .Include(c => c.Patient.Surgeries)
                .Include(c => c.Patient.CurrentMedications)
                .Include(v => v.Patient.VitalHistory)
                .Include(p => p.Assessment)
                .Single(p => p.Patient.Id.Equals(query));

            return patient;
        }

        public IEnumerable<Diagnosis> GetAllDiagnosisByPatientIdWithNav(int query)
        {
            var patient = repository.Diagnoses
                .Include(p => p.Vitals)
                .Include(p => p.Patient)
                .Include(p => p.Patient.UserProfile)
                .Include(c => c.Patient.Allergies)
                .Include(c => c.Patient.Conditions)
                .Include(c => c.Patient.Surgeries)
                .Include(c => c.Patient.CurrentMedications)
                .Include(v => v.Patient.VitalHistory)
                .Include(p => p.Assessment);

            return patient;
        }
    }
}