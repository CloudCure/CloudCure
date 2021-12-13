using System.ComponentModel.DataAnnotations;

namespace Models.Diagnosis
{
    public class Medication
    {
        public int Id { get; set; }
        public int PatientId { get; set; }

        //A listing of current medications taken by the patient
        [Display(Name = "Current Medications")]
        public string MedicationName { get; set; }
    }
}