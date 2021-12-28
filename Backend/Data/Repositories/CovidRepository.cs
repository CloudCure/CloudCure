using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;

//Grouping of classes for data access functionality
namespace Data
{

    //Inherits methods from Repository repo and Covid Repository interface
    public class CovidRepository : Repository<CovidVerify>, ICovidRepository
    {
        //Covid repository can only be defined in its Constructor
        readonly CloudCureDbContext repository;

        //Constructor sets CovidRepository class with DbContext class for database access
        public CovidRepository(CloudCureDbContext context) : base(context)
        {
            repository = context;
        }

        //Retrieves Covid Information from a user containing requested UserId
        public CovidVerify GetCovidInfoForUser(int p_Id)
        {
            try
            {
                return repository.CovidAssessments.Single(e => e.UserId.Equals(p_Id));
            }
            
            //Returns an exception if requested UserId was not found in the database
            catch (System.Exception)
            {
                throw new KeyNotFoundException("Employee Id Not Found!");
            }
        }
    }
}