using System;
using GeekMDSuite.Tools.Cardiology;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class PooledCohortsTests
    {
        [Fact]
        public void Test()
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Age).Returns(55);
            mockPatient.Setup(p => p.Gender.Category).Returns(GenderIdentity.Female);

            var ascvd = new PooledCohortsEquation(mockPatient.Object, BloodPressure.Build(120, 75), 213, 50).Calculate();

            Console.WriteLine($"ASCVD Risk%: {ascvd}");
            Assert.InRange(ascvd, 2.0, 2.2);
        }
    }
}