namespace GeekMDSuite.WebAPI.Models
{
    public class PatientEntity : Patient, IEntity
    {
        public int Id { get; set; }
    }
}