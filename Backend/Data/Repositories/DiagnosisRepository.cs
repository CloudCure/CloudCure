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
    }
     public Patient GetbyPatientIdWithNav(int query)
        {
            var patient = repository.Patients
                    .Include(p => p.UserProfile)
                    .Include(p => p.Assessments)
                    .Include(p => p.Conditions)
                    .Include(p => p.CurrentMedications)
                    .Include(p => p.Surgeries)
                    .Include(p => p.Allergies)
                    .Include(p => p.UserProfile.CovidAssesments)
                    .Single(p => p.Id.Equals(query));

            return patient;
        }
}