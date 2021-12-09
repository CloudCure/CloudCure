using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class CovidVerify
    {
        [Key]
        public int verificationID { get; set; }
        public int patientID {get; set;}
        public int patientName {get; set;}
        public string emailAddress { get; set; }
        public bool covidChoice { get; set; }
        
    }
}
