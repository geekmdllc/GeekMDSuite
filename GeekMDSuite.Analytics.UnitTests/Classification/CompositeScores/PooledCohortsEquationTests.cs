using System;
using GeekMDSuite.Analytics.Tools.Cardiology;
using GeekMDSuite.Core;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Classification.CompositeScores
{
    public partial class PooledCohortsEquationTests
    {
        [Fact]
        public void NullParameters_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                PooledCohortsEquation.Initialize(null));
        }

        public PooledCohortsEquationTests()
        {
            var dateOfBirth = DateTime.Now.AddYears(-55);
            _patient = PatientBuilder.Initialize()
                .SetDateOfBirth(dateOfBirth.Year, dateOfBirth.Month, dateOfBirth.Day)
                .BuildWithoutModelValidation();

            _parametersBuilder = PooledCohortEquationParametersBuilder.Initialize()
                .SetBloodPressure(BloodPressure.Build(120, 75))
                .SetHdlCholesterol(50)
                .SetTotalCholesterol(213);
        }

        private readonly Patient _patient;
        private readonly PooledCohortEquationParametersBuilder _parametersBuilder;
    }
}