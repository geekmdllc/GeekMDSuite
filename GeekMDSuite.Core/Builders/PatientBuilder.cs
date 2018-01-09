using System;
using System.Collections.Generic;
using GeekMDSuite.Core.Models;

namespace GeekMDSuite.Core.Builders
{
    public class PatientBuilder : Builder<PatientBuilder, Patient>
    {
        private readonly List<ChronicDisease> _comorbidities = new List<ChronicDisease>();

        private DateTime _dateOfBirth;
        private Gender _gender;
        private string _medicalRecordNumber;
        private Name _name;
        private Race _race;
        private bool _raceIsSet;

        public override Patient Build()
        {
            ValidatePreBuildState();
            return Patient.Build(_name, _dateOfBirth, _gender, _race, _medicalRecordNumber, _comorbidities);
        }


        public override Patient BuildWithoutModelValidation()
        {
            return new Patient
            {
                DateOfBirth = _dateOfBirth,
                Gender = _gender,
                MedicalRecordNumber = _medicalRecordNumber,
                Name = _name,
                Race = _race,
                Comorbidities = _comorbidities
            };
        }


        public PatientBuilder SetDateOfBirth(DateTime dateOfBirth)
        {
            _dateOfBirth = dateOfBirth;
            return this;
        }

        public PatientBuilder SetDateOfBirth(int year, int month, int day)
        {
            return SetDateOfBirth(new DateTime(year, month, day));
        }

        public PatientBuilder SetName(Name name)
        {
            _name = name;
            return this;
        }

        public PatientBuilder SetName(string first, string last, string middle = "")
        {
            return SetName(Name.Build(first, last, middle));
        }

        public PatientBuilder SetMedicalRecordNumber(string medicalRecordNumber)
        {
            _medicalRecordNumber = medicalRecordNumber;
            return this;
        }

        public PatientBuilder SetGender(GenderIdentity gender)
        {
            _gender = Gender.Build(gender);
            return this;
        }

        public PatientBuilder SetGender(Gender gender)
        {
            return SetGender(gender.Category);
        }

        public PatientBuilder SetRace(Race race)
        {
            _raceIsSet = true;
            _race = race;
            return this;
        }

        public PatientBuilder AddComorbidity(ChronicDisease comorbidity)
        {
            _comorbidities.Add(comorbidity);
            return this;
        }

        public PatientBuilder AddComorbidities(IEnumerable<ChronicDisease> comorbidities)
        {
            _comorbidities.AddRange(comorbidities);
            return this;
        }

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