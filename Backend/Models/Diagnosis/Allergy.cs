using System.ComponentModel.DataAnnotations;

namespace Models.Diagnosis
{
    public class Allergy
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        
       //This is Allergies that the patient may have
        [Display(Name = "Allergies")]
        public string AllergyName { get; set; }
    }
}