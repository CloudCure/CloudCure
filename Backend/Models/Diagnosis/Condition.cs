using System.ComponentModel.DataAnnotations;

namespace Models.Diagnosis
{
    public class Condition
    {
        public int Id { get; set; }
        public int PatientId { get; set; }

        //Condition name is name of family history conditions that the patient may have. 
        [Display(Name = "Medical Conditions")]
        public string ConditionName { get; set; }
    }
}