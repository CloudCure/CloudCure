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

        [Key]
        public int UserId {get; set;}
        
        [Required]
        public string FirstName {get; set;}

        [Required]
        public string LastName {get; set;}

        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string PhoneNumber {get; set;}

        [Required]
        public string Address {get; set;}

        [Required]
        public string EmergencyName {get; set;}

        [Required]
        public string EmergencyContactPhone {get; set;}

        [Required]
        public int RoleId {get; set;}

        public Role Role {get; set;}

    }



}