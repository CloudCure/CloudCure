using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Diagnosis
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        public List<Condition> Conditions { get; set; }

        public List<Allergy> Allergies { get; set; }

        public List<Surgery> Surgeries { get; set; }

        public List<Medication> CurrentMedications { get; set; }

        public List<Vitals> VitalHistory { get; set; }
        public List<Assessment> Assessments { get; set; }

        // covid assessment
        //public List<CovidVerify> CovidAssesments { get; set; }
    }
}
