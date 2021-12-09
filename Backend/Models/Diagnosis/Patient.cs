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
         [Display(Name = "Name")]
        [RegularExpression(@"^[a-zA-Z -]+$", ErrorMessage = "Invalid name")]
        public string PatientName { get; set; }

        [Required]
        [Display(Name = "Patient Phone")]
        [RegularExpression(@"^[0-9-]+$", ErrorMessage = "Invalid phone number")]
        public string PatientPhone { get; set; }

        [Required]
        [Display(Name = "Patient Address")]
        [RegularExpression(@"^[a-zA-Z0-9. ,-]+$", ErrorMessage = "Invalid address")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

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
