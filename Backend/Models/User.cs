using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class User
    {
        public int user_Id {get; set;}

        public string work_Email {get; set;}

        public string employee_Name {get; set;}

        public Boolean user_Type {get; set;}
    }
}