using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{

   public class UserRepository : Repository<User>, IUserRepository
   {
       readonly CloudCureDbContext repository;
       public UserRepository(CloudCureDbContext context) : base(context)
        {
            repository = context;
        }
    }
}