using System;
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
        [InlineData(Race.White, GenderIdentity.Female, false, false, false, 2.1)]
        [InlineData(Race.White, GenderIdentity.Female, true, false, false, 2.8)]
        [InlineData(Race.White, GenderIdentity.Female, false, true, false, 3.9)]
        [InlineData(Race.White, GenderIdentity.Female, false, false, true, 5.0)]
        [InlineData(Race.White, GenderIdentity.Female, true, true, false, 5.3)]
        [InlineData(Race.White, GenderIdentity.Female, true, false, true, 6.6)]
        [InlineData(Race.White, GenderIdentity.Female, false, true, true, 9.4)]
        [InlineData(Race.White, GenderIdentity.Male, false, false, false, 5.3)]
        [InlineData(Race.BlackOrAfricanAmerican, GenderIdentity.Female, false, false, false, 3.0)]
        [InlineData(Race.BlackOrAfricanAmerican, GenderIdentity.Male, false, false, false, 6.1)]
        public void PercentAscvdRisk_Given2013AccAhaSampleParams_ReturnsCorrectRiskPercentage(Race race,
            GenderIdentity genderIdentity, bool hypertensionTreatment, bool diabetes, 
            bool smoker, double expected)
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Age).Returns(55);
            mockPatient.Setup(p => p.Gender.Category).Returns(genderIdentity);
            mockPatient.Setup(p => p.Race).Returns(race);

            var ascvd = new PooledCohortsEquation(
                mockPatient.Object, 
                BloodPressure.Build(120, 75), 
                CholesterolTotal(213), 
                HighDensityLipoprotein(50),
                hypertensionTreatment, 
                diabetes, 
                smoker)
                .AscvdRiskPercentOver10Years();

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