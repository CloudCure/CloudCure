using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class User
    {

        public string work_Email {get; set;}

        public string employee_FirstName {get; set;}

        public string employee_LastName {get; set;}

        public string employee_Specialization {get; set;}

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string alternate_Email {get; set;}

        public string emergency_Contact {get; set;}

        public string Address { get; set; }

        public Boolean user_Role {get; set;}
    }



}