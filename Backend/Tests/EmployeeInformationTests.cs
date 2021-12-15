using System.Linq;
using System.Collections.Generic;
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
                Assert.Equal("John", EmployeeInfo.UserProfile.FirstName);
            }
        }

        /// <summary>
        /// Testing the Create method
        /// </summary>
        [Fact]
        public void CreateShouldWork()
        {
            EmployeeInformation newGuy = new EmployeeInformation
            {
                Id = 2,
                WorkEmail = "nurseBetty@email.com",
                EducationDegree = "RN",
                Specialization = "Pediatrics",
                RoomNumber = "7",
                StartDate = new DateTime(2021, 12, 15),
                UserProfile = new User
                {
                    Id = 2,
                    FirstName = "Betty",
                    LastName = "White",
                    Address = "14 Nurse St.",
                    DateOfBirth = new DateTime(1922, 01, 17),
                    EmergencyName = "Bea Arthur",
                    EmergencyContactPhone = "5556237462",
                    RoleId = 2,
                    Role = new Role
                    {
                        Id = 2,
                        RoleName = "Nurse"
                    }
                }
            };

            using (var context = new CloudCureDbContext(_options))
            {
                IEmployeeInformationRepository repo = new EmployeeInformationRepository(context);
                repo.Create(newGuy);

                List<EmployeeInformation> allEmps = repo.GetAll().ToList();

                Assert.Equal(2, allEmps.Count);
                Assert.Equal("RN", allEmps[1].EducationDegree);
                Assert.Equal("Betty", allEmps[1].UserProfile.FirstName);
                Assert.Equal("Nurse", allEmps[1].UserProfile.Role.RoleName);
            }
        }

        /// <summary>
        /// Making sure the Delete method works
        /// </summary>
        [Fact]
        public void DeleteShouldWork()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IEmployeeInformationRepository repo = new EmployeeInformationRepository(context);
                EmployeeInformation employee = repo.GetByPrimaryKey(1);
                repo.Delete(employee);
                List<EmployeeInformation> test = repo.GetAll().ToList();

                Assert.Equal(0, test.Count);
            }
        }

        [Fact]
        public void UpdateShouldWork()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IEmployeeInformationRepository repo = new EmployeeInformationRepository(context);
                EmployeeInformation employee = repo.GetEmployeeInformationById(1);
                employee.UserProfile.FirstName = "Jim";
                employee.Specialization = "Proctology";
                repo.Update(employee);
                EmployeeInformation test = repo.GetByPrimaryKey(1);

                Assert.Equal("Jim", test.UserProfile.FirstName);
                Assert.Equal("Proctology", test.Specialization);
            }
        }
        public void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Employee.Add(
                    new EmployeeInformation
                    {
                        Id = 1,
                        WorkEmail = "drJohn@email.com",
                        EducationDegree = "MD",
                        Specialization = "ER",
                        RoomNumber = "101",
                        StartDate = new DateTime(2021, 12, 14),
                        UserProfile = new User
                        {
                            Id = 1,
                            FirstName = "John",
                            LastName = "Doe",
                            Address = "123 Generic St",
                            DateOfBirth = new DateTime(1986, 12, 18),
                            EmergencyContactPhone = "1235551234",
                            EmergencyName = "Jane Doe",
                            PhoneNumber = "5557654321",
                            RoleId = 1,
                            Role = new Role
                            {
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