using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Diagnosis;

//Grouping of classes for data access functionality
namespace Data
{
    //Inherits methods from Repository repo and Patient Repository interface
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        //Patient repository can only be defined in its Constructor
        readonly CloudCureDbContext repository;

        //Constructor sets PatientRepository class with DbContext class for database access
        public PatientRepository(CloudCureDbContext context) : base(context)
        {
            repository = context;
        }

        //Retrieves patient information containing user requested PatientId
        public Patient GetbyPatientWithNav(int query)
        {
            //Patient contains information from multiple models such as allergies and conditions
            var patient = repository.Patients
                    .Include(p => p.UserProfile)
                    .Include(p => p.Conditions)
                    .Include(p => p.CurrentMedications)
                    .Include(p => p.Surgeries)
                    .Include(p => p.Allergies)
                    .Include(p => p.UserProfile.CovidAssesments)
                    .Include(p => p.Diagnoses)
                    .ThenInclude(d => d.Assessment)
                    .Include(p => p.Diagnoses)
                    .ThenInclude(d => d.Vitals)
                    .Include(p => p.Doctor.UserProfile)
                    .Single(p => p.Id.Equals(query));

            return patient;
        }

        //Retrieves list of all patients in the database
        public IEnumerable<Patient> GetAllWithNav()
        {
            var patients = this.repository.Patients
                .Include(p => p.UserProfile)
                    .Include(p => p.Conditions)
                    .Include(p => p.CurrentMedications)
                    .Include(p => p.Surgeries)
                    .Include(p => p.Allergies)
                    .Include(p => p.UserProfile.CovidAssesments)
                    .Include(p => p.Diagnoses)
                    .ThenInclude(d => d.Assessment)
                    .Include(p => p.Diagnoses)
                    .ThenInclude(d => d.Vitals)
                    .Include(p => p.Doctor.UserProfile)
                    .Where(p => p.Id > 0);

            return patients;
        }
    }
}