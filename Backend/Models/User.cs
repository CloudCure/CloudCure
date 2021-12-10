using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class User {
        public int Id {get;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Phone {get;set;}
        public string Address {get; set;}

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}