using System;
using GeekMDSuite.Procedures;

namespace GeekMDSuite
{
    public class PatientBuilder : IBuilder<Patient>
    {
        public Patient Build()
        {
            ValidatePreBuildState();
            return Patient.Create(_name, _dateOfBirth, _gender, _race, _medicalRecordNumber);
        }
        
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
            _raceIsSet = true;
            _race = race;
            return this;
        }

        private DateTime _dateOfBirth;
        private Name _name;
        private string _medicalRecordNumber;
        private Gender _gender;
        private Race _race;
        private bool _raceIsSet;

        private void ValidatePreBuildState()
        {
            var message = string.Empty;
            if (_dateOfBirth == default(DateTime)) message += $"{nameof(SetDateOfBirth)} ";
            if (_name == null) message += $"{nameof(SetName)} ";
            if (_medicalRecordNumber == string.Empty) message += $"{nameof(SetMedicalRecordNumber)} ";
            if (_gender == null) message += $"{nameof(SetGender)} ";
            if (!_raceIsSet) message += $"{nameof(SetRace)} ";

            if (!string.IsNullOrEmpty(message)) throw new MissingMethodException(message + " need to be set.");
        }
    }
}