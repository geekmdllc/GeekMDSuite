using System;

namespace GeekMDSuite.Core
{
    public class PatientBuilder : Builder<PatientBuilder,Patient>
    {
        public override Patient Build()
        {
            ValidatePreBuildState();
            return Patient.Build(_name, _dateOfBirth, _gender, _race, _medicalRecordNumber);
        }

        public override Patient BuildWithoutModelValidation() => new Patient()
        {
            DateOfBirth = _dateOfBirth,
            Gender = _gender,
            MedicalRecordNumber =  _medicalRecordNumber,
            Name = _name,
            Race = _race
        };

        public PatientBuilder SetDateOfBirth(int year, int month, int day) => SetDateOfBirth(new DateTime(year, month, day));

        public PatientBuilder SetDateOfBirth(DateTime dateOfBirth)
        {
            _dateOfBirth = dateOfBirth;
            return this;
        }

//        public PatientBuilder BornOn(int year, int month, int day) => SetDateOfBirth(year, month, day);
//        public PatientBuilder BornOn(DateTime dateOfBirth) => SetDateOfBirth(dateOfBirth);


        public PatientBuilder SetName(Name name)
        {
            _name = name;
            return this;
        }

        public PatientBuilder SetName(string first, string last, string middle = "") => SetName(Name.Build(first, last, middle));
//        public PatientBuilder HasName(string first, string last, string middle = "") => SetName(first, last, middle);
//        public PatientBuilder HasName(Name name) => SetName(name);

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
//        public PatientBuilder GenderIsMale() => SetGender(GenderIdentity.Male);
//        public PatientBuilder GenderIsFemale() => SetGender(GenderIdentity.Female);
//        public PatientBuilder GenderIsNonBinaryXy() => SetGender(GenderIdentity.NonBinaryXy);
//        public PatientBuilder GenderIsNonBinaryXx() => SetGender(GenderIdentity.NonBinaryXx);

        public PatientBuilder SetRace(Race race)
        {
            _raceIsSet = true;
            _race = race;
            return this;
        }

//        public PatientBuilder RaceIsAmericanOrAlaskanNative() => SetRace(Race.AmericanIndianOrAlaskaNative);
//        public PatientBuilder RaceIsAsian() => SetRace(Race.Asian);
//        public PatientBuilder RaceIsBlackOrAfricanAmerican() => SetRace(Race.BlackOrAfricanAmerican);
//        public PatientBuilder RaceIsLatin() => SetRace(Race.Latin);
//        public PatientBuilder RaceIsHawaiianOrPacificIslander() => SetRace(Race.NativeHawaiianOrOtherPacificIslander);
//        public PatientBuilder RaceIsUnknownRace() => SetRace(Race.Unknown);
//        public PatientBuilder RaceIsWhite() => SetRace(Race.White);

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