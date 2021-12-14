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
    }
}