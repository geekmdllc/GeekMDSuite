using System;
using GeekMDSuite.Analytics.Tools.Fitness;
using GeekMDSuite.Core.Builders;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.Utilities.MeasurementUnits;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Tools.Fitness
{
    public class Vo2MaxCalculationTests
    {
        public Vo2MaxCalculationTests()
        {
            _timeDuration = TimeDuration.Build(11, 33);
            _protocol = TreadmillProtocol.Bruce;
            _unsupportedProtocol = TreadmillProtocol.Balke3Point0;

            var dateOfBirth = DateTime.Now.AddYears(-45);
            _patient = PatientBuilder.Initialize()
                .SetGender(GenderIdentity.Male)
                .SetDateOfBirth(dateOfBirth.Year, dateOfBirth.Month, dateOfBirth.Day)
                .BuildWithoutModelValidation();
        }

        private readonly TimeDuration _timeDuration;
        private readonly TreadmillProtocol _protocol;
        private readonly TreadmillProtocol _unsupportedProtocol;
        private readonly Patient _patient;

        [Fact]
        public void FemaleResultInRange()
        {
            _patient.Gender = Gender.Build(GenderIdentity.Female);

            var result = CalculateVo2Max.FromTreadmillStressTest(_protocol, _timeDuration, _patient);
            Assert.InRange(result, 46, 47);
        }

        [Fact]
        public void MaleResultInRange()
        {
            _patient.Gender = Gender.Build(GenderIdentity.Male);

            var result = CalculateVo2Max.FromTreadmillStressTest(_protocol, _timeDuration, _patient);
            Assert.InRange(result, 40, 41);
        }

        [Fact]
        public void UnsupportedProtocolThrowsNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() =>
                CalculateVo2Max.FromTreadmillStressTest(_unsupportedProtocol, _timeDuration, _patient));
        }
    }
}