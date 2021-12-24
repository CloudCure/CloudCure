// using System;
// using Xunit;
// using Models.Diagnosis;
// using System.Collections.Generic;
// using Models;

// namespace Tests
// {
//     public class PatientModelTests
//     {
//         [Fact]
//         public void PatienModelShouldSetValidData()
//         {
//             User u = new User
//             {
//                 FirstName = "John",
//                 LastName = "Doe",
//                 PhoneNumber = "5551234567",
//                 Address = "123 Test St",
//                 DateOfBirth = DateTime.Now,
//                 EmergencyName = "Jane Doe",
//                 EmergencyContactPhone = "5557654321",
//                 RoleId = 1
//             };
//             List<Condition> c = new List<Condition>
//             {
//                 new Condition
//                 {
//                     PatientId = 1,
//                     ConditionName = "Headache",
//                 }
//             };
//             List<Allergy> a = new List<Allergy>
//             {
//                 new Allergy{
//                     AllergyName = "Nuts",
//                     PatientId = 1
//                 }
//             };
//             List<Surgery> s = new List<Surgery>
//             {
//                 new Surgery{
//                     PatientId = 1,
//                     SurgeryName = "Tummy Tuck"
//                 }
//             };
//             List<Medication> m = new List<Medication>
//             {
//                 new Medication{
//                     PatientId = 1,
//                     MedicationName = "Advil"
//                 }
//             };
//             List<Vitals> v = new List<Vitals>
//             {
//                 new Vitals{
//                     PatientId = 1,
//                     Diastolic = 70,
//                     Systolic = 120,
//                     HeartRate = 70,
//                     Height = 75,
//                     Weight = 200,
//                     OxygenSat = 98.2,
//                     Temperature = 97.2,
//                     RespiratoryRate = 14,
//                 }
//             };
//             List<Assessment> assesments = new List<Assessment>
//             {
//                 new Assessment{
//                     PatientId = 1,
//                     PainAssessment = "asdfas",
//                     PainScale = 2,
//                     ChiefComplaint = "Headache",
//                     HistoryOfPresentIllness = "Yup"
//                 }
//             };
//             List<Models.Diagnosis.Diagnosis> d = new List<Models.Diagnosis.Diagnosis>
//             {
//                 new Models.Diagnosis.Diagnosis
//                 {
//                     Id = 1,
//                     EncounterDate = new DateTime(2021, 12, 22),
//                     Patient = GetPatient(),
//                     Vitals = new Vitals{
//                         PatientId = 1,
//                         Diastolic = 70,
//                         Systolic = 120,
//                         HeartRate = 70,
//                         Height = 75,
//                         Weight = 200,
//                         OxygenSat = 98.2,
//                         Temperature = 97.2,
//                         RespiratoryRate = 14,
//                     },
//                     Assessment = new Assessment
//                     {
//                         PatientId = 1,
//                         PainAssessment = "asdfas",
//                         PainScale = 2,
//                         ChiefComplaint = "Headache",
//                         HistoryOfPresentIllness = "Yup"
//                     },
//                     DoctorDiagnosis = "Healthy",
//                     RecommendedTreatment = "Live Life",
//                     IsFinalized = true
//                 }
//             };
//             EmployeeInformation doc = new EmployeeInformation
//             {
//                 UserProfile = new User
//                 {
//                     FirstName = "Pepper"
//                 }
//             };

//             Patient test = new Patient();
//             test.Id = 1;
//             test.UserProfile = u;
//             test.Conditions = c;
//             test.Allergies = a;
//             test.Surgeries = s;
//             test.CurrentMedications = m;
//             test.Diagnoses = d;
//             test.Doctor = doc;

//             Assert.Equal(1, test.Id);
//             Assert.Equal(u, test.UserProfile);
//             Assert.Equal(c, test.Conditions);
//             Assert.Equal(a, test.Allergies);
//             Assert.Equal(s, test.Surgeries);
//             Assert.Equal(m, test.CurrentMedications);
//             Assert.Equal(d, test.Diagnoses);
//             Assert.Equal(doc.UserProfile.FirstName, test.Doctor.UserProfile.FirstName);
//         }

//         private Patient GetPatient()
//         {
//             return new Patient
//             {
//                 UserProfile = new User
//                 {

//                     FirstName = "John",
//                     LastName = "Doe",
//                     PhoneNumber = "5551234567",
//                     Address = "123 Test St",
//                     DateOfBirth = DateTime.Now,
//                     EmergencyName = "Jane Doe",
//                     EmergencyContactPhone = "5557654321",
//                     RoleId = 1

//                 },
//                 Conditions = new List<Condition>()
//                 {
//                     new Condition{
//                         PatientId = 1,
//                         ConditionName = "Headache",
//                     }
//                 },
//                 Allergies = new List<Allergy>()
//                 {
//                     new Allergy{
//                         AllergyName = "Nuts",
//                         PatientId = 1
//                     }
//                 },
//                 Surgeries = new List<Surgery>()
//                 {
//                     new Surgery{
//                         PatientId = 1,
//                         SurgeryName = "Tummy Tuck"
//                     }
//                 },
//                 CurrentMedications = new List<Medication>()
//                 {
//                     new Medication{
//                         PatientId = 1,
//                         MedicationName = "Advil"
//                     }
//                 }
//             };
//         }
//     }
// }