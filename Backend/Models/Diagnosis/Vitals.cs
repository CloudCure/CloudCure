using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Diagnosis
{
    public class Vitals

    {
        [Key]
        public int VitalsId { get; set; }

        public int PatientId { get; set; }

        [Required]
        public int Systolic {get ; set;}

        [Required]
        public int Diastolic  { get; set; }

        [Required]
        public double OxygenSat {get; set;}

        [Required]
        public int HeartRate {get; set;}

        [Required]
        public int RespiratoryRate {get; set;}

        [Required]
        public double Tempature { get; set; }

        [Required]
        public double Height {get; set;}

        [Required]
        public double Weight {get; set;}

        [Column(TypeName = "date")]
        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EncounterDate {get; set;}
    }
}