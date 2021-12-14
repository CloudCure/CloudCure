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

      public IEnumerable<Allergy> SearchByPatientId(int query)
        {
            var result = base.GetAll()
                        .Where(i => i.PatientId.Equals(query));
            if (!result.Any())
            {
                throw new KeyNotFoundException("No result found");
            }

            return result;


        }
    }
}