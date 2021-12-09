using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class User
    {

        public string work_Email {get; set;}

        public string employee_FirstName {get; set;}

        public string employee_LastName {get; set;}

        public Boolean user_Type {get; set;}
    }
}