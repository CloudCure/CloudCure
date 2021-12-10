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

        public string first_Name {get; set;}

        public string last_Name {get; set;}

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string phone_Number {get; set;}

        public string address {get; set;}

        public int role_ID {get; set;}

        public int user_ID {get; set;}

        public Role role {get; set;}

    }



}