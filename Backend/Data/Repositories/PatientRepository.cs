using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Diagnosis;

namespace Data
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        readonly CloudCureDbContext repository;
        public PatientRepository(CloudCureDbContext context) : base(context)
        {
            repository = context;
        }

        public Patient GetbyPatientWithNav(int query)
        {
            var patient = repository.Patients
                    .Include(p => p.UserProfile)
                    .Include(p => p.Assessments)
                    .Include(p => p.Conditions)
                    .Include(p => p.CurrentMedications)
                    .Include(p => p.Surgeries)
                    .Include(p => p.Allergies)
                    .Include(p => p.VitalHistory)
                    .Include(p => p.UserProfile.CovidAssesments)
                    .Include(p => p.Doctor.UserProfile)
                    .Single(p => p.Id.Equals(query));

            return patient;
        }

        public IEnumerable<Patient> GetAllWithNav()
        {
            var patients = this.repository.Patients
                .Include(p => p.UserProfile)
                    .Include(p => p.Assessments)
                    .Include(p => p.Conditions)
                    .Include(p => p.CurrentMedications)
                    .Include(p => p.Surgeries)
                    .Include(p => p.Allergies)
                    .Include(p => p.VitalHistory)
                    .Include(p => p.UserProfile.CovidAssesments)
                    .Include(p => p.Doctor.UserProfile)
                    .Where(p => p.Id > 0);

            return patients;
        }
    }
}