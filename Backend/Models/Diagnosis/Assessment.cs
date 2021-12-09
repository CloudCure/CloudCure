using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Diagnosis
{

    public class Assessment
    {
        [Key]
        public int AssessmentId { get; set; }

        public int PatientId { get; set; }

        [Required]
        public string ChiefComplaint { get; set; }

        [Required]
        public string HistoryOfPresentIllness { get; set; }

        // body clicker comma separated string
        public string PainAssessment { get; set; }

        public int PainScale { get; set; }
    }
}