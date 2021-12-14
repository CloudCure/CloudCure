using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class UserProfile
    {

        public string WorkEmail {get; set;}

        public string EmployeeFirstName {get; set;}

        public string EmployeeLastName {get; set;}

        public string EmployeePhoneNumber {get; set;}

        public string EmployeeSpecialization {get; set;}

        public string AlternateEmail {get; set;}

        public string EmergencyContact {get; set;}

        public string UserRole {get; set;}
    }
}