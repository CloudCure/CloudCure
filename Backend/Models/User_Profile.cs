using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class User_Profile
    {

        public string work_Email {get; set;}

        public string employee_FirstName {get; set;}

        public string employee_LastName {get; set;}

        public string employee_PhoneNumber {get; set;}

        public string employee_Specialization {get; set;}

        public string alternate_Email {get; set;}

        public string emergency_Contact {get; set;}

        public string user_Role {get; set;}
    }
}