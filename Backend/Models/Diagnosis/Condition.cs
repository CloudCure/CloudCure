namespace Models.Diagnosis
{
    public class Condition
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string ConditionName { get; set; }
    }
}