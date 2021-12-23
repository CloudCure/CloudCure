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
        readonly IPatientRepository patientRepository;
        readonly IAssessmentRepository assessmentRepository;
        public DiagnosisRepository(CloudCureDbContext context, IPatientRepository pcontext, IAssessmentRepository asscontext) : base(context)
        {
            repository = context;
            patientRepository = pcontext;
            assessmentRepository = asscontext;
        }

        public Diagnosis GetByPatientIdWithNav(int query)
        {
            var diagnosis = repository.Diagnoses
            .Include(d => d.Vitals)
            .Include(d => d.Assessment)
                .Single(d => d.Patient.Id.Equals(query));

            var patient = repository.Patients
                .Include(p => p.UserProfile)
                .Single(p => p.Id.Equals(query));

            diagnosis.Patient = patient;

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