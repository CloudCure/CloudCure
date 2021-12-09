using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
public class PatientModelse
{
    [Key]
    public int PatientId { get; set; }

    [Required]
    [Display(Name = "Patient Name")]
    public string PatientName { get; set; }

    [Required]
    [Display(Name ="Patient Phone")]
    public string PatientPhone { get; set; }

    [Required]
    [Display(Name ="Patient Address")]
    public string Address { get; set; }

    [Column(TypeName = "date")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }    
}
}
