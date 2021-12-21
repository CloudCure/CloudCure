using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Diagnosis
{
    public class Diagnosis
    {
        public int Id { get; set; }

        //Date and time of the encounter.  
        [Column(TypeName = "date")]
        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EncounterDate { get; set; }
        public Patient Patient { get; set; }
        public Vitals Vitals { get; set; }
        public Assessment Assessment { get; set; }

        public string DoctorDiagnosis { get; set; }
        public string RecommendedTreatment { get; set; }
    }
}