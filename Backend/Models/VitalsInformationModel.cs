using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class VitalsInformationModel

    {
        [Key]
        public int VitalsId { get; set; }

        [Required]
        public int Systolic {get ; set;}

        [Required]
        public int Diastolic  { get; set; }

        [Required]
        public int PatientId {get; set;}

        [Required]
        public int HeartRate {get; set;}

        [Required]
        public double Tempature { get; set; }

        [Required]
        public int RespiratoryRate {get; set;}

        [Required]
        public int PainSeverity {get; set;}

        public string PainLocation {get; set;}

        [Required]
        public double Height {get; set;}

        [Required]
        public double Weight {get; set;}

        [Required]
        public double OxygenSat {get; set;}

        [Column(TypeName = "date")]
        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EncounterDate {get; set;}
    }
}