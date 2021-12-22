using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Diagnosis;

namespace Data
{

    public class ConditionRepository : Repository<Condition>, IConditionRepository
    {
        readonly CloudCureDbContext repository;
        public ConditionRepository(CloudCureDbContext context) : base(context)
        {
            repository = context;
        }

        public IEnumerable<Condition> SearchByCondition(string query)
        {
            var Condition = GetAll().Where(b => b.ConditionName.Equals(query));
            if (!Condition.Any())
            {
                throw new KeyNotFoundException("Condition not found.");
            }
            else
            {
                return Condition;
            }
        }

        public IEnumerable<Condition> SearchByPatientId(int p_patientId)
        {
            var result = base.GetAll()
                        .Where(i => i.PatientId.Equals(p_patientId));
            if (!result.Any())
            {
                throw new KeyNotFoundException("No result found");
            }

            return result;


        }

    
    }
}

