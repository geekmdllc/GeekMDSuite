using System;
using GeekMDSuite.Extensions;

namespace GeekMDSuite
{
    public class Patient : IPatient
    {
        public Patient()
        {
            
        }
        public Patient(IName name, DateTime dateOfBirth, IGender gender, Race race, string medicalRecordNumber)
        {
            DateOfBirth = dateOfBirth;
            Name = name;
            MedicalRecordNumber = medicalRecordNumber;
            Gender = gender;
            Race = race;
        }

        public DateTime DateOfBirth { get; }
        public int Age => DateOfBirth.ElapsedYears();
        public IName Name { get; }
        public string MedicalRecordNumber { get; }
        public IGender Gender { get; }
        public Race Race { get; }

        internal static Patient Build(IName name, DateTime dateOfBirth, IGender gender, Race race, string medicalRecordNumber) 
            => new Patient(name, dateOfBirth, gender, race, medicalRecordNumber);

        public override string ToString()
        {
            return string.Format($@"{Name} ({Age} yr {Race} {Gender}) MRN: {MedicalRecordNumber}");
        }
    }
}