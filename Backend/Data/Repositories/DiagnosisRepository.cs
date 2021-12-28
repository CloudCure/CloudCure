using Models.Diagnosis;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


//Grouping of classes for data access functionality
namespace Data
{


    //Inherits methods from Repository repo and Diagnosis Repository interface
    public class DiagnosisRepository : Repository<Diagnosis>, IDiagnosisRepository
    {
        //Diagnosis repository can only be defined in its Constructor
        readonly CloudCureDbContext repository;

        //Constructor sets DiagnosisRepository class with DbContext class for database access
        public DiagnosisRepository(CloudCureDbContext context) : base(context)
        {
            repository = context;
        }

        //Retrieves diagnosis form containing user requested PatientId
        public Diagnosis GetByPatientIdWithNav(int query)
        {
            //Diagnosis form contains Vitals and Assessments forms
            var diagnosis = repository.Diagnoses
            .Include(d => d.Vitals)
            .Include(d => d.Assessment)
                .Single(d => d.PatientId.Equals(query));

            return diagnosis;

        }

        //Retrieves list of Diagnosis forms containing user requested PatientId
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