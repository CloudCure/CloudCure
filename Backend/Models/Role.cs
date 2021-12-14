using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models {
    public class Role{
        [Key]
        public int Id {get; set;}

        [Required]
        public string RoleName {get; set;}

        






    }






}