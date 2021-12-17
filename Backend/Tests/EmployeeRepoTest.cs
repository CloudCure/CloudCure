
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Xunit;

namespace Tests
{
    public class EmployeeRepoTest
    {
        readonly DbContextOptions<CloudCureDbContext> _options;

        public EmployeeRepoTest()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                        .UseSqlite("Filename = Employee.db; Foreign Keys=False").Options;
            Seed();
        }

        [Fact]
        public void VerifyEmailShouldReturnAnEmployeeWithMatchingEmail()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IEmployeeInformationRepository _repo = new EmployeeInformationRepository(context);
                string _testEmail = "Employee@example.com";
                var result = _repo.VerifyEmail(_testEmail);

                Assert.NotNull(result);
                Assert.Equal("112", result.RoomNumber);
            }
        }


        void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Employee.AddRange(
                    new EmployeeInformation
                    {
                        WorkEmail = "Employee@example.com",
                        Specialization = "Cardiologist",
                        StartDate = DateTime.Now,
                        RoomNumber = "112",
                        EducationDegree = "Yale",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
