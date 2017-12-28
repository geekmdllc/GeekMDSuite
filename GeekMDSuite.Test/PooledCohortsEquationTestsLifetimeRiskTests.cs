﻿using GeekMDSuite.Tools.Cardiology;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public partial class PooledCohortsEquationTests
    {
        [Theory]
        [InlineData(GenderIdentity.Male, 240, 160, true, true, true, 69)]
        [InlineData(GenderIdentity.Male, 240, 159, false, false, false, 50)]
        [InlineData(GenderIdentity.Male, 239, 159, false, false, false, 46)]
        [InlineData(GenderIdentity.Male, 199, 125, false, false, false, 36)]
        [InlineData(GenderIdentity.Male, 179, 119, false, false, false, 5)]
        [InlineData(GenderIdentity.Female, 240, 160, true, true, true, 50)]
        [InlineData(GenderIdentity.Female, 240, 159, false, false, false, 39)]
        [InlineData(GenderIdentity.Female, 239, 159, false, false, false, 39)]
        [InlineData(GenderIdentity.Female, 199, 125, false, false, false, 27)]
        [InlineData(GenderIdentity.Female, 179, 119, false, false, false, 8)]
        public void PercentAscvdRiskLifetime_GivenValues_ReturnsCorrectRiskPercentage(
            GenderIdentity gender, double totalCholesterol,
            int systolicBloodPressure, bool hypertensionTreatment, bool diabetes,
            bool smoker, double expected)
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Gender.Category).Returns(gender);

            _parametersBuilder
                .SetPatient(mockPatient.Object)
                .SetBloodPressure(systolicBloodPressure, 75)
                .SetTotalCholesterol(totalCholesterol)
                .SetHdlCholesterol(50);
            
            if (hypertensionTreatment) _parametersBuilder.ConfirmOnAntiHypertensiveMedication();
            if (diabetes) _parametersBuilder.ConfirmDiabetic();
            if (smoker) _parametersBuilder.ConfirmSmoker();

            var lifetime = PooledCohortsEquation.Initialize(_parametersBuilder.Build()).AscvdLifetimeRiskPercentage;

            const double tolerance = 0.1;
            Assert.InRange(lifetime, expected - tolerance, expected + tolerance);
        }

        [Theory]
        [InlineData(GenderIdentity.Female, 8.0)]
        [InlineData(GenderIdentity.Male, 5.0)]
        public void IdealLifeTimeRisk_IsCorrect(GenderIdentity genderIdentity, double expectedRisk)
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(p => p.Gender.Category).Returns(genderIdentity);

            _parametersBuilder
                .SetPatient(mockPatient.Object)
                .SetBloodPressure(default(int), default(int))
                .SetTotalCholesterol(default(int))
                .SetHdlCholesterol(default(int));

            var idealAscvdLifetimeRisk = PooledCohortsEquation.Initialize(_parametersBuilder.Build()).IdealAscvdLifetimeRiskPercentage;

            const double tolerance = 0.1;
            Assert.InRange(idealAscvdLifetimeRisk, expectedRisk - tolerance, expectedRisk + tolerance);
        }
    }
}