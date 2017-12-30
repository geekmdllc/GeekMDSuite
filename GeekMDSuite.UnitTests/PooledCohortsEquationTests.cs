using System;
using GeekMDSuite.Tools.Cardiology;
using Moq;
using Xunit;

namespace GeekMDSuite.UnitTests
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
            _patient = new Patient()
            {
                DateOfBirth = DateTime.Now.AddYears(-55)
            };

            _parametersBuilder = PooledCohortEquationParametersBuilder.Initialize()
                .SetBloodPressure(BloodPressure.Build(120, 75))
                .SetHdlCholesterol(50)
                .SetTotalCholesterol(213);
        }

        private readonly Patient _patient;
        private readonly PooledCohortEquationParametersBuilder _parametersBuilder;
    }
}