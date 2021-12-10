using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models{
    public class employee_Information{
        public int user_ID {get; set;}

        public string work_Email {get; set;}

        public string specialization {get; set;}

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime start_Date {get; set;}

        public string room_Number {get; set;}

        public string education_Degree {get; set;}

    } 



}