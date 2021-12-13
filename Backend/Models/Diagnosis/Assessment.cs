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


        // small blurb that the patient has a complaint on. For example the patient would say "I've had a cough" or "my ankle hurts". 
        //Chief Complaint is the primary reason that a patient is presenting to the clinic that day. 
        [Required]
        public string ChiefComplaint { get; set; }

        //History of present illness is detailed information regarding the chief complaint 
        //HOPI is a documentation of everything the patient describes about the issues they're presenting with 
        [Required]
        public string HistoryOfPresentIllness { get; set; }

        // body clicker comma separated string
        public string PainAssessment { get; set; }


        //Pain scale is a question asked of the patient to assess their pain on a scale of 0-10. 
        // 0 being no paint 10 being the most pain to ever be felt.
        [Range(0, 10, ErrorMessage = "Number must be 0 to 10")]
        public int PainScale { get; set; }
    }
}