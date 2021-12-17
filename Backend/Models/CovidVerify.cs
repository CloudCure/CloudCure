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
        public string question1 { get; set; }
        [Required]
        public string question2 { get; set; }
        [Required]
        public string question3 { get; set; }
        [Required]
        public string question4 { get; set; }
        [Required]
        public string question5 { get; set; }
        [Required]
        public int UserId { get; set; }
        
    }
}
