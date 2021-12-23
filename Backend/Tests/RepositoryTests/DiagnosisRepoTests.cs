using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Diagnosis;
using Models;
using Xunit;

namespace Tests
{
    public class DiagnosisRepoTests
    {
        readonly DbContextOptions<CloudCureDbContext> _options;

        public DiagnosisRepoTests()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                .UseSqlite("Filename = DiagnosisRepoTests.db; Foreign Keys=False").Options;
            Seed();
        }

        [Fact]
        public void GetByPatientIdWithNavShouldWork()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IDiagnosisRepository repo = new DiagnosisRepository(context);
                Models.Diagnosis.Diagnosis test = repo.GetByPatientIdWithNav(1);

                Assert.NotNull(test);
                // Assert.Equal("John", test.Patient.UserProfile.FirstName);
                // Assert.Equal("Headache", test.Patient.Conditions[0].ConditionName);
                // Assert.Equal(70, test.Vitals.HeartRate);
                // Assert.Equal("Nuts", test.Patient.Allergies[0].AllergyName);
                // Assert.Equal("He's fine", test.DoctorDiagnosis);
                // Assert.Equal(70, test.Patient.VitalHistory[0].HeartRate);
            }
        }

        [Fact]
        public void GellAllWithNavShouldWork()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IDiagnosisRepository repo = new DiagnosisRepository(context);
                List<Models.Diagnosis.Diagnosis> results = repo.GetAllDiagnosisByPatientIdWithNav(1).ToList();

                Assert.NotEmpty(results);
            }
        }

        private void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Models.Diagnosis.Diagnosis test = new Models.Diagnosis.Diagnosis();
                DateTime date = new DateTime(2021, 12, 22);
                Patient p = new Patient
                {
                    UserProfile = new User
                    {

                        FirstName = "John",
                        LastName = "Doe",
                        PhoneNumber = "5551234567",
                        Address = "123 Test St",
                        DateOfBirth = DateTime.Now,
                        EmergencyName = "Jane Doe",
                        EmergencyContactPhone = "5557654321",
                        RoleId = 1

                    },
                    Conditions = new List<Condition>()
                    {
                        new Condition
                        {
                            PatientId = 1,
                            ConditionName = "Headache",
                        }
                    },
                    Allergies = new List<Allergy>()
                    {
                        new Allergy
                        {
                            AllergyName = "Nuts",
                            PatientId = 1
                        }
                    },
                    Surgeries = new List<Surgery>()
                    {
                        new Surgery
                        {
                            PatientId = 1,
                            SurgeryName = "Tummy Tuck"
                        }
                    },
                    CurrentMedications = new List<Medication>()
                    {
                        new Medication
                        {
                            PatientId = 1,
                            MedicationName = "Advil"
                        }
                    },
                    VitalHistory = new List<Vitals>()
                    {
                        new Vitals
                        {
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
                        new Assessment
                        {
                            PatientId = 2,
                            PainAssessment = "asdfas",
                            PainScale = 2,
                            ChiefComplaint = "dfdssdf",
                            HistoryOfPresentIllness = "dssdfs"
                        }
                    }
                };
                Vitals v = p.VitalHistory[0];
                Assessment a = p.Assessments[0];
                string docDiagnosis = "He's fine";
                string treatment = "Live life";

                test.Id = 1;
                test.EncounterDate = date;
                test.Patient = p;
                test.Vitals = v;
                test.Assessment = a;
                test.DoctorDiagnosis = docDiagnosis;
                test.RecommendedTreatment = treatment;

                context.Add(test);
                context.SaveChanges();
            }
        }
    }
}