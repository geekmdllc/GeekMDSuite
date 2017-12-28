using System;
using System.ComponentModel.DataAnnotations.Schema;
using GeekMDSuite.Extensions;

namespace GeekMDSuite.WebAPI.Models
{
    public class PatientEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public NameModel Name { get; set; }
        public string MedicalRecordNumber { get; set; }
        public GenderModel Gender { get; set; }
        public Race Race { get; set; }
        [NotMapped]
        public int Age => DateOfBirth.ElapsedYears();

        public PatientEntity(IPatient patient) : this()
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));
            DateOfBirth = patient.DateOfBirth;
            Name = new NameModel(patient.Name);
            MedicalRecordNumber = patient.MedicalRecordNumber;
            Gender = new GenderModel(patient.Gender);
            Race = patient.Race;
        }

        public PatientEntity()
        {
            DateOfBirth = new DateTime();
            Name = new NameModel();
            Gender = new GenderModel();
        }
    }
}