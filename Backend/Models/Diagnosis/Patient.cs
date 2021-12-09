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

        [Required]
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }

        [Required]
        [Display(Name = "Patient Phone")]
        public string PatientPhone { get; set; }

        [Required]
        [Display(Name = "Patient Address")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public List<Condition> Conditions { get; set; }

        public List<Allergy> Allergies { get; set; }

        public List<Surgery> Surgeries { get; set; }

        public List<Vitals> VitalHistory { get; set; }

        public List<Medication> CurrentMedications { get; set; }
        public List<Assessment> Assessments { get; set; }
    }
}