using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Diagnosis
{
    public class Vitals

    {
        [Key]
        public int Id { get; set; }

        public int DiagnosisId { get; set; }

        //This is measuring blood pressure.  This is the Top number of the blood pressure
        [Required]
        public int Systolic { get; set; }


        //This is measuring blood pressure.  This is the bottom number of blood pressure
        [Required]
        public int Diastolic { get; set; }

        //This is 02 Saturation.  The saturation of oxygen in a persons blood. 
        [Required]
        public double OxygenSat { get; set; }

        //This is the heart rate of the patient
        [Required]
        public int HeartRate { get; set; }

        //This is the respitory rate of the patient
        [Required]
        public int RespiratoryRate { get; set; }

        //This is the tempature of the patient
        [Required]
        public double Temperature { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        public double Weight { get; set; }
    }
}