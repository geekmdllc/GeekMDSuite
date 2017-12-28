﻿using System;
using GeekMDSuite.Services.Interpretation;
using Moq;
using Xunit;
using static GeekMDSuite.Services.Interpretation.PercentBodyFatInterpretation.LowerLimits;

namespace GeekMDSuite.Test
{
    public class PercentBodyFatTest
    {
        [Theory]
        [InlineData(Male.Athletic - 1, GenderIdentity.Male, PercentBodyFat.UnderFat)]
        [InlineData(Male.Athletic, GenderIdentity.Male, PercentBodyFat.Athletic)]
        [InlineData(Male.Fit, GenderIdentity.Male, PercentBodyFat.Fitness)]
        [InlineData(Male.Acceptable, GenderIdentity.Male, PercentBodyFat.Acceptable)]
        [InlineData(Male.OverFat, GenderIdentity.Male, PercentBodyFat.OverFat)]
        [InlineData(Female.Athletic - 1, GenderIdentity.Female, PercentBodyFat.UnderFat)]
        [InlineData(Female.Athletic, GenderIdentity.Female, PercentBodyFat.Athletic)]
        [InlineData(Female.Fit, GenderIdentity.Female, PercentBodyFat.Fitness)]
        [InlineData(Female.Acceptable, GenderIdentity.Female, PercentBodyFat.Acceptable)]
        [InlineData(Female.OverFat, GenderIdentity.Female, PercentBodyFat.OverFat)]
        public void Classify_GivenBodyCompositionAndBodyFatPercent_ReturnsCorrectClassification(double percentBodyFat, 
            GenderIdentity genderIdentity, PercentBodyFat expectedClassification)
        {
            _patient.Gender = Gender.Build(genderIdentity);
            
            var bce = new Mock<IBodyCompositionExpanded>();
            bce.Setup(b => b.PercentBodyFat).Returns(percentBodyFat);
            
            var classification = new PercentBodyFatInterpretation(bce.Object, _patient).Classification;
            
            Assert.Equal(expectedClassification, classification);
        }

        [Fact]
        public void GivenNullBodyComposition_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new PercentBodyFatInterpretation(null, new Mock<IPatient>().Object));
        }

        [Fact]
        public void GivenNullPatient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new PercentBodyFatInterpretation(new Mock<IBodyCompositionExpanded>().Object, null));
        }

        public PercentBodyFatTest()
        {
            _patient = new Patient();
        }
        
        private readonly Patient _patient;
    }
}