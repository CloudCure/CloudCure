using System;
using System.Collections.Generic;
using Data;
using Moq;
using Xunit;
using WebAPI.Controllers;
using Models.Diagnosis;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Models;

namespace Tests
{
    public class PatientControllerTests
    {
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
            var repository = new Mock<IPatientRepository>();
            var repository2 = new Mock<IAllergyRepository>();
            var controller = new PatientController(repository.Object, repository2.Object);

            try
            {
                var result = controller.Add(null);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }
        }

        [Fact]
        public void GetAllShouldGetAll()
        {
            var repository = new Mock<IPatientRepository>();
            var repository2 = new Mock<IAllergyRepository>();
            var controller = new PatientController(repository.Object, repository2.Object);

            var patient = newPatient();

            var entry = controller.Add(patient);
            var result = controller.GetAll();
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void GetAllShouldThrowAnException()
        {
            var repository = new Mock<IPatientRepository>();
            var repository2 = new Mock<IAllergyRepository>();
            var controller = new PatientController(repository.Object, repository2.Object);

            try
            {
                var result = controller.GetAll();
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
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
            var repository = new Mock<IPatientRepository>();
            var repository2 = new Mock<IAllergyRepository>();
            var controller = new PatientController(repository.Object, repository2.Object);

            try
            {
                var result = controller.Delete(null);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }
        }

        [Fact]
        public void UpdateShouldUpdatePatient()
        {
            var repository = new Mock<IPatientRepository>();
            var repository2 = new Mock<IAllergyRepository>();
            var controller = new PatientController(repository.Object, repository2.Object);

            var patient = newPatient();

            var entry = controller.Add(patient);
            var result = controller.Update(1, patient);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void UpdateShouldThrowAnException()
        {
            var repository = new Mock<IPatientRepository>();
            var repository2 = new Mock<IAllergyRepository>();
            var controller = new PatientController(repository.Object, repository2.Object);

            try
            {
                var result = controller.Update(1, null);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }
        }

        [Fact]
        public void GetByIdShouldGetPatientById()
        {
            var repository = new Mock<IPatientRepository>();
            var repository2 = new Mock<IAllergyRepository>();
            var controller = new PatientController(repository.Object, repository2.Object);

            var patient = newPatient();

            var entry = controller.Add(patient);
            var result = controller.GetById(1);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void GetByIdShouldThrowAnException()
        {
            var repository = new Mock<IPatientRepository>();
            var repository2 = new Mock<IAllergyRepository>();
            var controller = new PatientController(repository.Object, repository2.Object);

            try
            {
                var result = controller.GetById(1);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }
        }

        private Patient newPatient()
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
                },
                VitalHistory = new List<Vitals>()
                {
                    new Vitals{
                        PatientId = 1,
                        Diastolic = 70,
                        Systolic = 120,
                        HeartRate = 70,
                        Height = 75,
                        Weight = 200,
                        OxygenSat = 98.2,
                        Temperature = 97.2,
                        RespiratoryRate = 14,
                        EncounterDate = DateTime.Now

                    }
                },
                Assessments = new List<Assessment>()
                {
                    new Assessment{
                        PatientId = 2,
                        PainAssessment = "asdfas",
                        PainScale = 2,
                        ChiefComplaint = "dfdssdf",
                        HistoryOfPresentIllness = "dssdfs"
                    }
                }
            };

            return patient;
        }
    }
}