using System;
using System.Collections.Generic;
using GeekMDSuite.Core.Extensions;

namespace GeekMDSuite.Core.Models
{
    public class Patient : IEntity<Patient>
    {
        
        public Patient()
        {
            DateOfBirth = new DateTime();
            Name = new Name();
            Gender = new Gender();
            Guid = Guid.Empty;
            Comorbidities = new List<ChronicDisease>();
        }

        private Patient(
            Name name, 
            DateTime dateOfBirth, 
            Gender gender, 
            Race race, 
            string medicalRecordNumber,
            List<ChronicDisease> comorbidities) : this()
        {
            DateOfBirth = dateOfBirth;
            Name = name;
            MedicalRecordNumber = medicalRecordNumber;
            Gender = gender;
            Race = race;
            Comorbidities = comorbidities;
        }

        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age => DateOfBirth.ElapsedYears();
        public Name Name { get; set; }
        public string MedicalRecordNumber { get; set; }
        public Gender Gender { get; set; }
        public Race Race { get; set; }
        public List<ChronicDisease> Comorbidities { get; set; }

        public void MapValues(Patient subject)
        {
            Comorbidities.Clear();
            Comorbidities.AddRange(subject.Comorbidities);
            Guid = subject.Guid;
            DateOfBirth = subject.DateOfBirth;
            Name.First = subject.Name.First;
            Name.Middle = subject.Name.Middle;
            Name.Last = subject.Name.Last;
            MedicalRecordNumber = subject.MedicalRecordNumber;
            Gender.Category = subject.Gender.Category;
            Race = subject.Race;
        }

        public override string ToString() => $@"{Name} ({Age} yr {Race} {Gender}) MRN: {MedicalRecordNumber}";

        internal static Patient Build(
            Name name, 
            DateTime dateOfBirth, 
            Gender gender, 
            Race race, 
            string medicalRecordNumber,
            List<ChronicDisease> comorbidities) 
            => new Patient(name, dateOfBirth, gender, race, medicalRecordNumber, comorbidities);
    }
}