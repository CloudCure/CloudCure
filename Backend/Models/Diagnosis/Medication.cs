namespace Models.Diagnosis
{
    public class Medication
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string MedicationName { get; set; }
    }
}