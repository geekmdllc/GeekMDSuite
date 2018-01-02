using System;
using GeekMDSuite.Core;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class PatientEntity : Patient, IEntity<Patient>
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }

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

        public void MapValues(Patient subject)
        {
            DateOfBirth = subject.DateOfBirth;
            Gender.Category = subject.Gender.Category;
            MedicalRecordNumber = subject.MedicalRecordNumber;
            Name.First = subject.Name.First;
            Name.Middle = subject.Name.Middle;
            Name.Last = subject.Name.Last;
            Race = subject.Race;
        }
    }
}