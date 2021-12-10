using System.ComponentModel.DataAnnotations;

namespace Models.Diagnosis
{
    public class Surgery
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }

        //Previous surgeries undergone by the patient.
        [Display(Name = "Previous Surgeries")]
        public string SurgeryName { get; set; }
    }
}