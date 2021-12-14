using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Models;
using Data;

namespace Tests
{
    public class EmployeeInformationTests
    {
        readonly DbContextOptions<CloudCureDbContext> _options;

        public EmployeeInformationTests()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                .UseSqlite("Filename = EmployeeInfo.db; Foreign Keys=False").Options;
            Seed();
        }

        /// <summary>
        /// Tests GetEmployeeInformationById method
        /// </summary>
        [Fact]
        public void SearchByEmpIdShouldReturnResults()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                 IEmployeeInformationRepository repo = new EmployeeInformationRepository(context);
                 var EmployeeInfo = repo.GetEmployeeInformationById(1);

                 Assert.NotNull(EmployeeInfo);
                 Assert.Equal("MD", EmployeeInfo.EducationDegree);
                 Assert.Equal("ER", EmployeeInfo.Specialization);
                 Assert.Equal(new DateTime(2021, 12, 14), EmployeeInfo.StartDate);
            }
        }

        public void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Employee.Add(
                    new EmployeeInformation{
                        Id = 1,
                        WorkEmail = "drJohn@email.com",
                        EducationDegree = "MD",
                        Specialization = "ER",
                        RoomNumber = "101",
                        StartDate = new DateTime(2021, 12, 14),
                        UserProfile = new User{
                            Id = 1,
                            FirstName = "John",
                            LastName = "Doe",
                            Address = "123 Generic St",
                            DateOfBirth = new DateTime(1986, 12, 18),
                            EmergencyContactPhone = "1235551234",
                            EmergencyName = "Jane Doe",
                            PhoneNumber = "5557654321",
                            RoleId = 1,
                            Role = new Role{
                                Id = 1,
                                RoleName = "Doctor"
                            }
                        }
                    }
                );
                context.SaveChanges();
            }
        }
    }
}