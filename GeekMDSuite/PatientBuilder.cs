using System;

namespace GeekMDSuite
{
    public class PatientBuilder
    {
        private DateTime _dateOfBirth;
        private Name _name;
        private string _medicalRecordNumber;
        private Gender _gender;
        private Race _race;

        public PatientBuilder SetDateOfBirth(int year, int month, int day)
        {
            _dateOfBirth = new DateTime(year, month, day);
            return this;
        }

        public PatientBuilder SetName(string first, string last, string middle = "")
        {
            _name = Name.Create(first, last, middle);
            return this;
        }

        public PatientBuilder SetMedicalRecordNumber(string medicalRecordNumber)
        {
            _medicalRecordNumber = medicalRecordNumber;
            return this;
        }

        public PatientBuilder SetGender(GenderIdentity gender)
        {
            _gender = Gender.Create(gender);
            return this;
        }

        public PatientBuilder SetRace(Race race)
        {
            _race = race;
            return this;
        }

        public Patient Build()
        {
            return Patient.Create(_name, _dateOfBirth, _gender, _race, _medicalRecordNumber);
        }
    }
}