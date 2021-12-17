using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Models;
using Data;

namespace Tests
{
    public class EmployeeInfoRepoTests
    {
        readonly DbContextOptions<CloudCureDbContext> _options;

        public EmployeeInfoRepoTests()
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
        /// Testing the VerifyEmail method to make sure it returns the expected result
        /// </summary>
        [Fact]
        public void VerifyEmailShouldReturnMatchingEmail()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IEmployeeInformationRepository repo = new EmployeeInformationRepository(context);
                string testEmail = "drJohn@email.com";
                var result = repo.VerifyEmail(testEmail);

                Assert.NotNull(result);
                Assert.Equal("101", result.RoomNumber);
            }
        }

        /// <summary>
        /// Testing the Create method
        /// </summary>
        [Fact]
        public void CreateShouldWork()
        {
            List<CovidVerify> covidList = new List<CovidVerify>();
            covidList.Add(
                new CovidVerify
                {
                    question1 = "true",
                    question2 = "true",
                    question3 = "true",
                    question4 = "true",
                    question5 = "true"
                }
            );
            EmployeeInformation newGuy = new EmployeeInformation
            {
                WorkEmail = "nurseBetty@email.com",
                EducationDegree = "RN",
                Specialization = "Pediatrics",
                RoomNumber = "7",
                StartDate = new DateTime(2021, 12, 15),
                UserProfile = new User
                {
                    FirstName = "Betty",
                    LastName = "White",
                    Address = "14 Nurse St.",
                    DateOfBirth = new DateTime(1922, 01, 17),
                    EmergencyName = "Bea Arthur",
                    EmergencyContactPhone = "5556237462",
                    CovidAssesments = covidList,
                    RoleId = 2,
                    Role = new Role
                    {
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
                Assert.Equal("true", allEmps[1].UserProfile.CovidAssesments[0].question1);
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
                EmployeeInformation employee = repo.GetById(1);
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
                employee.UserProfile.CovidAssesments[0].question1 = "false";
                repo.Update(employee);
                EmployeeInformation test = repo.GetById(1);

                Assert.Equal("Jim", test.UserProfile.FirstName);
                Assert.Equal("Proctology", test.Specialization);
                Assert.Equal("false", employee.UserProfile.CovidAssesments[0].question1);
            }
        }
        public void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                List<CovidVerify> covidList = new List<CovidVerify>();
                covidList.Add(
                    new CovidVerify
                    {
                        question1 = "true",
                        question2 = "true",
                        question3 = "true",
                        question4 = "true",
                        question5 = "true"
                    }
                );

                context.Employee.Add(
                    new EmployeeInformation
                    {
                        WorkEmail = "drJohn@email.com",
                        EducationDegree = "MD",
                        Specialization = "ER",
                        RoomNumber = "101",
                        StartDate = new DateTime(2021, 12, 14),
                        UserProfile = new User
                        {
                            FirstName = "John",
                            LastName = "Doe",
                            Address = "123 Generic St",
                            DateOfBirth = new DateTime(1986, 12, 18),
                            EmergencyContactPhone = "1235551234",
                            EmergencyName = "Jane Doe",
                            PhoneNumber = "5557654321",
                            CovidAssesments = covidList,
                            RoleId = 1,
                            Role = new Role
                            {
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