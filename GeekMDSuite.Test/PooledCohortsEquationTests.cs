using System;
using GeekMDSuite.Tools.Cardiology;
using Moq;
using Xunit;
using static GeekMDSuite.LaboratoryData.Builder.Quantitative.Serum;

namespace GeekMDSuite.Test
{
    public class PooledCohortsEquationTests
    {
        [Theory]
        [InlineData(Race.White, GenderIdentity.Female, false, false, false, 2.1)]
        [InlineData(Race.White, GenderIdentity.Female, true, false, false, 2.8)]
        [InlineData(Race.White, GenderIdentity.Female, false, true, false, 3.9)]
        [InlineData(Race.White, GenderIdentity.Female, false, false, true, 5.0)]
        [InlineData(Race.White, GenderIdentity.Female, true, true, false, 5.3)]
        [InlineData(Race.White, GenderIdentity.Female, true, false, true, 6.6)]
        [InlineData(Race.White, GenderIdentity.Female, false, true, true, 9.4)]
        [InlineData(Race.White, GenderIdentity.Female, true, true, true, 12.5)]
        [InlineData(Race.White, GenderIdentity.Male, false, false, false, 5.3)]
        [InlineData(Race.White, GenderIdentity.Male, true, false, false, 6.3)]
        [InlineData(Race.White, GenderIdentity.Male, false, true, false, 10.1)]
        [InlineData(Race.White, GenderIdentity.Male, false, false, true, 10.0)]
        [InlineData(Race.White, GenderIdentity.Male, true, true, false, 11.8)]
        [InlineData(Race.White, GenderIdentity.Male, true, false, true, 11.6)]
        [InlineData(Race.White, GenderIdentity.Male, false, true, true, 18.4)]
        [InlineData(Race.White, GenderIdentity.Male, true, true, true, 21.2)]
        [InlineData(Race.BlackOrAfricanAmerican, GenderIdentity.Female, false, false, false, 3.0)]
        [InlineData(Race.BlackOrAfricanAmerican, GenderIdentity.Female, true, false, false, 4.6)]
        [InlineData(Race.BlackOrAfricanAmerican, GenderIdentity.Female, false, true, false, 7.1)]
        [InlineData(Race.BlackOrAfricanAmerican, GenderIdentity.Female, false, false, true, 5.9)]
        [InlineData(Race.BlackOrAfricanAmerican, GenderIdentity.Female, true, true, false, 10.6)]
        [InlineData(Race.BlackOrAfricanAmerican, GenderIdentity.Female, true, false, true, 8.9)]
        [InlineData(Race.BlackOrAfricanAmerican, GenderIdentity.Female, false, true, true, 13.7)]
        [InlineData(Race.BlackOrAfricanAmerican, GenderIdentity.Female, true, true, true, 20.1)]
        [InlineData(Race.BlackOrAfricanAmerican, GenderIdentity.Male, false, false, false, 6.1)]
        [InlineData(Race.BlackOrAfricanAmerican, GenderIdentity.Male, true, false, false, 9.9)]
        [InlineData(Race.BlackOrAfricanAmerican, GenderIdentity.Male, false, true, false, 11.3)]
        [InlineData(Race.BlackOrAfricanAmerican, GenderIdentity.Male, false, false, true, 10.3)]
        [InlineData(Race.BlackOrAfricanAmerican, GenderIdentity.Male, true, true, false, 18.1)]
        [InlineData(Race.BlackOrAfricanAmerican, GenderIdentity.Male, true, false, true, 16.6)]
        [InlineData(Race.BlackOrAfricanAmerican, GenderIdentity.Male, false, true, true, 18.7)]
        [InlineData(Race.BlackOrAfricanAmerican, GenderIdentity.Male, true, true, true, 29.2)]
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
                    smoker, 
                    diabetes)
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