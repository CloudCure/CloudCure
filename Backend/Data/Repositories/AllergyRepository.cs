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

        // public Patient SearchByPatientId(int query)
        // {
        //     throw new NotImplementedException();
        // }
    }
}
