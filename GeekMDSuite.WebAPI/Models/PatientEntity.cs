using System;

namespace GeekMDSuite.WebAPI.Models
{
    public class PatientEntity : IEntity, IPatient
    {
        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public IName Name { get; set; }
        public string MedicalRecordNumber { get; set; }
        public IGender Gender { get; set; }
        public Race Race { get; set; }
    }
}