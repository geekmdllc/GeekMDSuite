using System;
using GeekMDSuite.Extensions;

namespace GeekMDSuite
{
    public class Patient : IPatient
    {
        public Patient(Name name, DateTime dateOfBirth, IGender gender, Race race, string medicalRecordNumber)
        {
            DateOfBirth = dateOfBirth;
            Name = name;
            MedicalRecordNumber = medicalRecordNumber;
            Gender = gender;
            Race = race;
        }

        public DateTime DateOfBirth { get; }
        public int Age => DateOfBirth.ElapsedYears();
        public Name Name { get; }
        public string MedicalRecordNumber { get; }
        public IGender Gender { get; }
        public Race Race { get; }
    }
}