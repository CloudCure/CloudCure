namespace Models.Diagnosis
{
    public class Allergy
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string AllergyName { get; set; }
    }
}