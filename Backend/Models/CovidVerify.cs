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
        public int Id { get; set; }
        [Required]
        public int UsersId {get; set;}
        [Required]
        public bool covidChoice { get; set; }
        
    }
}
