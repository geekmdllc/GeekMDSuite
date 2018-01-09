using System;
using GeekMDSuite.Analytics.Tools.Cardiology;
using GeekMDSuite.Core.Builders;
using GeekMDSuite.Core.Models;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Classification.CompositeScores
{
    public partial class PooledCohortsEquationTests
    {
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

        [Fact]
        public void NullParameters_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new PooledCohortsEquation(null));
        }
    }
}