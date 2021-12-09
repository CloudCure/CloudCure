using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class VitalsInformation

    {
        [Key]
        public int VitalsId { get; set; }
        public int Systolic {get ; set;}

        public int Diastolic  { get; set; }

        [Required]
        public int PatientId {get; set;}

        public int HeartRate {get; set;}

        public double Tempature { get; set; }

        public int RespiratoryRate {get; set;}

        public int PainSeverity {get; set;}

        public string PainLocation {get; set;}

        public double Height {get; set;}

        public double Weight {get; set;}

        public double OxygenSat {get; set;}

        public DateTime? EncounterDate {get; set;}
    }
}