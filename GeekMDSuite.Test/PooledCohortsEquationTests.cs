using System;
using GeekMDSuite.Tools.Cardiology;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
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
            _patientMock= new Mock<IPatient>(); 
            _patientMock.Setup(p => p.Age).Returns(55);

            _parametersBuilder = PooledCohortEquationParametersBuilder.Initialize()
                .SetBloodPressure(BloodPressure.Build(120, 75))
                .SetHdlCholesterol(50)
                .SetTotalCholesterol(213);
        }

        private readonly Mock<IPatient> _patientMock;
        private readonly PooledCohortEquationParametersBuilder _parametersBuilder;
    }
}