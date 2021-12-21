using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Diagnosis;
using Xunit;

namespace Tests.Diagnosis
{
    public class PatientTest
    {
        readonly DbContextOptions<CloudCureDbContext> _options;

        public PatientTest()
        {
            _options = new DbContextOptionsBuilder<CloudCureDbContext>()
                        .UseSqlite("Filename = Patienttest.db; Foreign Keys=False").Options;
            Seed();
        }


        [Fact]
        public void GetByIdWithNavShouldPopulateNavProps()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IPatientRepository repository = new PatientRepository(context);
                var patient = repository.GetbyPatientWithNav(1);

                Assert.NotNull(patient.Conditions);
            }
        }

        [Fact]
        public void GetAllWithNavShouldWork()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                IPatientRepository repository = new PatientRepository(context);                
                var patients = repository.GetAllWithNav();
                
                Assert.NotEmpty(patients);
            }
        }

        void Seed()
        {
            using (var context = new CloudCureDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Patients.Add(
                    new Patient
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
                        },
                    }

                );
                context.SaveChanges();
            }
        }
    }
}
