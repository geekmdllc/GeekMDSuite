using System;
using GeekMDSuite.LaboratoryData.Builder;
using GeekMDSuite.Tools.Cardiology;
using Moq;
using Xunit;
using static GeekMDSuite.LaboratoryData.Builder.Quantitative.Serum;

namespace GeekMDSuite.Test
{
    public class PooledCohortsTests
    {
        // Data from 2013 ACC/AHA Cardiovascular Risk Guideline (Goff DC Jr, et al.)
        [Theory]
        [InlineData(Race.White, GenderIdentity.Female, 2.1)]
        [InlineData(Race.White, GenderIdentity.Male, 5.3)]
        [InlineData(Race.BlackOrAfricanAmerican, GenderIdentity.Female, 3.0)]
        [InlineData(Race.BlackOrAfricanAmerican, GenderIdentity.Male, 6.1)]
        public void PercentAscvdRisk_Given2013AccAhaSampleParams_ReturnsCorrectRiskPercentage(Race race,
            GenderIdentity genderIdentity, double expected)
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Age).Returns(55);
            mockPatient.Setup(p => p.Gender.Category).Returns(genderIdentity);
            mockPatient.Setup(p => p.Race).Returns(race);

            var ascvd = new PooledCohortsEquation(mockPatient.Object, BloodPressure.Build(120, 75), CholesterolTotal(213), HighDensityLipoprotein(50)).AscvdRiskPercentOver10Years();

            const double tolerance = 0.1;
            Console.WriteLine($"ASCVD Risk%: {ascvd}");
            Assert.InRange(ascvd, expected - tolerance, expected + tolerance);
        }

        [Fact]
        public void NullPatient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new PooledCohortsEquation(null, new Mock<IBloodPressure>().Object, CholesterolTotal(213), HighDensityLipoprotein(50)));
        }
        
        [Fact]
        public void NullBloodPressure_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new PooledCohortsEquation(new Mock<IPatient>().Object, null, CholesterolTotal(213), HighDensityLipoprotein(50)));
        }
    }
}