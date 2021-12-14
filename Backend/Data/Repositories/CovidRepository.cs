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
        /// <summary>
        /// Acquiring Covid Verificaiton By User ID
        /// </summary>
        /// <param name="userId">int to locate user for which we're trying to find verificaiton</param>
        /// <returns>The Covid Verification</returns>
        public CovidVerify GetCovidVerificationByUserId(int userId)
        {
            return repository.CovidAssessments.Single(c => c.UsersId.Equals(userId));
        } 
    }
}