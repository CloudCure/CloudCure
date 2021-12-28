using System;
using System.Collections.Generic;
using Data;
using Moq;
using Xunit;
using WebAPI.Controllers;
using Models.Diagnosis;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Models;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class PatientControllerTests
    {
        readonly DbContextOptions<CloudCureDbContext> _options;

        public PatientControllerTests()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                        .UseSqlite("Filename = patientControllerTests.db; Foreign Keys=False").Options;
            Seed();
        }

        [Fact]
        public void CreateReturnsOk()
        {
            var repository = new Mock<IPatientRepository>();
            var repository2 = new Mock<IAllergyRepository>();
            var controller = new PatientController(repository.Object, repository2.Object);

            var patient = newPatient();

            var result = controller.Add(patient);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(201, okResponse.StatusCode);
        }

        [Fact]
        public void CreateShouldThrowAnException()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IPatientRepository repo1 = new PatientRepository(context);
                IAllergyRepository repo2 = new AllergyRepository(context);
                var controller = new PatientController(repo1, repo2);

                var result = controller.Add(null);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void GetAllShouldGetAll()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IPatientRepository repo1 = new PatientRepository(context);
                IAllergyRepository repo2 = new AllergyRepository(context);
                var controller = new PatientController(repo1, repo2);

                var result = controller.GetAll();
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void GetAllShouldThrowAnException()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IPatientRepository repo1 = new PatientRepository(context);
                IAllergyRepository repo2 = new AllergyRepository(context);
                var controller = new PatientController(repo1, repo2);

                context.Database.EnsureDeleted();

                var result = controller.GetAll();
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void DeleteShouldDeleteEntry()
        {
            var repository = new Mock<IPatientRepository>();
            var repository2 = new Mock<IAllergyRepository>();
            var controller = new PatientController(repository.Object, repository2.Object);

            var patient = newPatient();

            var entry = controller.Add(patient);
            var result = controller.Delete(patient);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void DeleteShouldThrowAnException()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IPatientRepository repo1 = new PatientRepository(context);
                IAllergyRepository repo2 = new AllergyRepository(context);
                var controller = new PatientController(repo1, repo2);

                var result = controller.Delete(null);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void UpdateShouldUpdatePatient()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IPatientRepository repo1 = new PatientRepository(context);
                IAllergyRepository repo2 = new AllergyRepository(context);
                var controller = new PatientController(repo1, repo2);

                var p = newPatient();

                var result = controller.Update(1, p);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void UpdateShouldThrowAnException()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IPatientRepository repo1 = new PatientRepository(context);
                IAllergyRepository repo2 = new AllergyRepository(context);
                var controller = new PatientController(repo1, repo2);

                var result = controller.Update(-1, null);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        [Fact]
        public void GetByIdShouldGetPatientById()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IPatientRepository repo1 = new PatientRepository(context);
                IAllergyRepository repo2 = new AllergyRepository(context);
                var controller = new PatientController(repo1, repo2);

                var result = controller.GetById(1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(200, response.StatusCode);
            }
        }

        [Fact]
        public void GetByIdShouldThrowAnException()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IPatientRepository repo1 = new PatientRepository(context);
                IAllergyRepository repo2 = new AllergyRepository(context);
                var controller = new PatientController(repo1, repo2);

                var result = controller.GetById(-1);
                var response = (IStatusCodeActionResult)result;
                Assert.Equal(400, response.StatusCode);
            }
        }

        private static Patient newPatient()
        {
            var patient = new Patient
            {
                UserProfile = new User
                {

                    FirstName = "dldfk",
                    LastName = "sdfksdf",
                    PhoneNumber = "dkfadl",
                    Address = "dkfjskld",
                    DateOfBirth = DateTime.Now,
                    EmergencyName = "dfdsfsdf",
                    EmergencyContactPhone = "fdksfdsd",
                    RoleId = 1

                },
                Conditions = new List<Condition>()
                {
                    new Condition{
                        PatientId = 1,
                        ConditionName = "dddf",

                    }
                },
                Allergies = new List<Allergy>()
                {
                    new Allergy{
                        AllergyName = "dddfd",
                        PatientId = 1
                    }
                },
                Surgeries = new List<Surgery>()
                {
                    new Surgery{
                        PatientId = 1,
                        SurgeryName = "dfkjdf"
                    }
                },
                CurrentMedications = new List<Medication>()
                {
                    new Medication{
                        PatientId = 1,
                        MedicationName = "dfdsf"
                    }
                }
                
               
            };

            return patient;
        }

        private void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Patient p = newPatient();

                context.Patients.Add(p);
                context.SaveChanges();
            }
        }
    }
}