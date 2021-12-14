using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Diagnosis;

namespace Data
{

   public class AllergyRepository : Repository<Allergy>, IAllergyRepository
   {
       readonly CloudCureDbContext repository;
       public AllergyRepository(CloudCureDbContext context) : base(context)
        {
            repository = context;
        }

        public IEnumerable<Allergy> SearchByAllergy(string query)
        {
             var allergy = GetAll().Where(b => b.AllergyName.Equals(query));
            if (!allergy.Any())
            {
                throw new KeyNotFoundException("Allergy not found.");
            }
            else
            {
                return allergy;
            }
        }

        public Allergy SearchByPatientId(int query)
        {
             var patientId = GetAll().First(b => b.PatientId.Equals(query));
            if (patientId == null)
            {
                throw new KeyNotFoundException("Topic not found.");
            }
            else
            {
                return patientId;
            }
        }
    }
}