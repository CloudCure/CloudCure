using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{

    public class CovidRepository : Repository<CovidVerify>, ICovidRepository
    {
        readonly CloudCureDbContext repository;
        public CovidRepository(CloudCureDbContext context) : base(context)
        {
            repository = context;
        }

        public CovidVerify GetCovidInfoForUser(int p_Id)
        {
            try
            {
                return repository.CovidAssessments
                .Include(q => q.question1)
                .Include(q => q.question2)
                .Include(q => q.question3)
                .Include(q => q.question4)
                .Include(q => q.question5)
                .Single(e => e.UserId.Equals(p_Id));
            }
            catch (System.Exception)
            {
                throw new KeyNotFoundException("Employee Id Not Found!");
            }
        }
    }
}