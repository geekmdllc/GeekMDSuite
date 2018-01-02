using System;
using GeekMDSuite.Core.Extensions;

namespace GeekMDSuite.Core
{
    public class Patient : IPatient
    {
        public Patient(Name name, DateTime dateOfBirth, Gender gender, Race race, string medicalRecordNumber)
        {
            DateOfBirth = dateOfBirth;
            Name = name;
            MedicalRecordNumber = medicalRecordNumber;
            Gender = gender;
            Race = race;
        }

        public DateTime DateOfBirth { get; set; }
        public int Age => DateOfBirth.ElapsedYears();
        public Name Name { get; set; }
        public string MedicalRecordNumber { get; set; }
        public Gender Gender { get; set; }
        public Race Race { get; set; }

        public override string ToString()
        {
            return string.Format($@"{Name} ({Age} yr {Race} {Gender}) MRN: {MedicalRecordNumber}");
        }

        internal static Patient Build(Name name, DateTime dateOfBirth, Gender gender, Race race, string medicalRecordNumber) 
            => new Patient(name, dateOfBirth, gender, race, medicalRecordNumber);
        
        protected internal Patient()
        {
            DateOfBirth = new DateTime();
            Name = new Name();
            Gender = new Gender();
        }
    }
}