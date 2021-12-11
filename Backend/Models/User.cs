using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class User {
        public int Id {get;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string PhoneNumber {get;set;}
        public string Address {get; set;}

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string EmergencyName {get; set;}

        [Required]
        public string EmergencyContactPhone {get; set;}

        [Required]
        public int RoleId {get; set;}

        public Role Role {get; set;}


    }
}