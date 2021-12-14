using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Diagnosis;

namespace Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string EmergencyName { get; set; }

        [Required]
        public string EmergencyContactPhone { get; set; }

        [Required]
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public List<CovidVerify> CovidAssesments { get; set; }
    }



}