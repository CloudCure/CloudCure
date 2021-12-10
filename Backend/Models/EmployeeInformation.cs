using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models{
    public class EmployeeInformation{
        [Key]
        public int UserID {get; set;}

        [Required]
        public string WorkEmail {get; set;}

        [Required]
        public string Specialization {get; set;}

        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime StartDate {get; set;}

        public string RoomNumber {get; set;}

        [Required]
        public string EducationDegree {get; set;}

    } 



}