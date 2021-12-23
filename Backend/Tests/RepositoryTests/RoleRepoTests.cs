using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Models;
using Data;

namespace Tests
{
    public class RoleRepoTests
    {
        readonly DbContextOptions<CloudCureDbContext> _options;

        public RoleRepoTests()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                .UseSqlite("Filename = RoleRepoTest.db; Foreign Keys=False").Options;
            Seed();
        }

        [Fact]
        public void RoleRepoShouldCreateRepo()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IRoleRepository repo = new RoleRepository(context);
                var result = repo.GetAll();

                Assert.NotNull(result);
            }
        }

        [Fact]
        public void GetRoleIdShouldGetRoleId()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IRoleRepository repository = new RoleRepository(context);
                var role = repository.GetById(1);

                Assert.Equal(1, role.Id);
            }
        }
        
        void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Role entry = new Role
                {
                    RoleName = "Doctor"
                };
                context.Roles.Add(entry);
                context.SaveChanges();
            }
        }
    }
}