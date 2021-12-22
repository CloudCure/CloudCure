using System;
using Xunit;
using Models.Diagnosis;
using System.Collections.Generic;
using Models;

namespace Tests
{
    public class DiagnosisModelTests
    {
        [Fact]
        public void DiagnosisModelShouldSetValidData()
        {
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
                    new Condition{
                        PatientId = 1,
                        ConditionName = "Headache",
                    }
                },
                Allergies = new List<Allergy>()
                {
                    new Allergy{
                        AllergyName = "Nuts",
                        PatientId = 1
                    }
                },
                Surgeries = new List<Surgery>()
                {
                    new Surgery{
                        PatientId = 1,
                        SurgeryName = "Tummy Tuck"
                    }
                },
                CurrentMedications = new List<Medication>()
                {
                    new Medication{
                        PatientId = 1,
                        MedicationName = "Advil"
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

            Assert.Equal(1, test.Id);
            Assert.Equal(date, test.EncounterDate);
            Assert.Equal(p.UserProfile.FirstName, test.Patient.UserProfile.FirstName);
            Assert.Equal(v, test.Vitals);
            Assert.Equal(a, test.Assessment);
            Assert.Equal(docDiagnosis, test.DoctorDiagnosis);
            Assert.Equal(treatment, test.RecommendedTreatment);
        }
    }
}