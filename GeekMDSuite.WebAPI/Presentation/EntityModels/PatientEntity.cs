using System;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class PatientEntity : Patient, IEntity<Patient>
    {
        public PatientEntity()
        {
        }

        public PatientEntity(Patient patient) : this()
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));

            MapValues(patient);
        }

        public Guid Guid { get; set; }
        public int Id { get; set; }

        public void MapValues(Patient subject)
        {
            if (subject == null) throw new ArgumentNullException(nameof(subject));

            DateOfBirth = subject.DateOfBirth;
            Gender.Category = subject.Gender.Category;
            MedicalRecordNumber = subject.MedicalRecordNumber;
            Name.First = subject.Name.First;
            Name.Middle = subject.Name.Middle;
            Name.Last = subject.Name.Last;
            Race = subject.Race;
            Comorbidities.Clear();
            Comorbidities.AddRange(subject.Comorbidities);
        }
    }
}