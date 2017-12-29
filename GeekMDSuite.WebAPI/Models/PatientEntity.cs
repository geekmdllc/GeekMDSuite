namespace GeekMDSuite.WebAPI.Models
{
    public class PatientEntity : Patient, IEntity
    {
        public int Id { get; set; }

        public PatientEntity()
        {
            
        }

        public PatientEntity(Patient patient)
        {
            DateOfBirth = patient.DateOfBirth;
            Gender = patient.Gender;
            MedicalRecordNumber = patient.MedicalRecordNumber;
            Name = patient.Name;
            Race = patient.Race;
        }
    }
}