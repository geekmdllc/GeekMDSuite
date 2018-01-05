using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Models.Procedures;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Classification
{
    public class CarotidUltrasoundInterpretationTests
    {
        [Fact]
        public void Classification_GivenLeftSidedPlaque_ReturnsLeftWorseThanRightStenosis()
        {
            var left = new CarotidUltrasoundResultBuilder()
                .SetImtGrade(CarotidIntimaMediaThicknessGrade.Mild)
                .SetIntimaMediaThickeness(0.812)
                .SetPlaqueCharacter(CarotidPlaqueCharacter.Mixed)
                .SetPercentStenosisGrade(CarotidPercentStenosisGrade.LessThan30)
                .Build();

            var right = new CarotidUltrasoundResultBuilder()
                .SetIntimaMediaThickeness(0.791)
                .Build();

            var us = CarotidUltrasound.Build(left, right);

            var result = new CarotidUltrasoundClassification(us);
            
            Assert.Equal(Laterality.Left, result.Classification.WorseSide);
        }
        [Fact]
        public void Classification_GivenLeftSidedPlaque_ReturnsLeftLaterality()
        {
            var left = new CarotidUltrasoundResultBuilder()
                .SetImtGrade(CarotidIntimaMediaThicknessGrade.Mild)
                .SetIntimaMediaThickeness(0.812)
                .SetPlaqueCharacter(CarotidPlaqueCharacter.Mixed)
                .SetPercentStenosisGrade(CarotidPercentStenosisGrade.LessThan30)
                .Build();

            var right = new CarotidUltrasoundResultBuilder()
                .SetIntimaMediaThickeness(0.791)
                .Build();
            
            var us = CarotidUltrasound.Build(left, right);

            var result = new CarotidUltrasoundClassification(us);
            
            Assert.Equal(Laterality.Left, result.Classification.Laterality);
        }
        [Fact]
        public void Classification_GivenRightSidedPlaque_ReturnsRightWorseThanRightStenosis()
        {
            var left = new CarotidUltrasoundResultBuilder()
                .SetIntimaMediaThickeness(0.791)
                .Build();
            
            var right = new CarotidUltrasoundResultBuilder()
                .SetImtGrade(CarotidIntimaMediaThicknessGrade.Mild)
                .SetIntimaMediaThickeness(0.812)
                .SetPlaqueCharacter(CarotidPlaqueCharacter.Mixed)
                .SetPercentStenosisGrade(CarotidPercentStenosisGrade.LessThan30)
                .Build();
            
            var us = CarotidUltrasound.Build(left, right);

            var result = new CarotidUltrasoundClassification(us);
            
            Assert.Equal(Laterality.Right, result.Classification.WorseSide);
        }
        [Fact]
        public void Classification_GivenRightSidedPlaque_ReturnsRightLaterality()
        {
            var left = new CarotidUltrasoundResultBuilder()
                .SetIntimaMediaThickeness(0.812)
                .Build();
            
            var right = new CarotidUltrasoundResultBuilder()
                .SetImtGrade(CarotidIntimaMediaThicknessGrade.Mild)
                .SetIntimaMediaThickeness(0.791)
                .SetPlaqueCharacter(CarotidPlaqueCharacter.Mixed)
                .SetPercentStenosisGrade(CarotidPercentStenosisGrade.LessThan50)
                .Build();
            
            var us = CarotidUltrasound.Build(left, right);

            var result = new CarotidUltrasoundClassification(us);
            
            Assert.Equal(Laterality.Right, result.Classification.Laterality);
        }
        [Fact]
        public void Classification_GivenEqualPlaque_ReturnsBilateralLaterality()
        {
            var left = new CarotidUltrasoundResultBuilder()
                .SetImtGrade(CarotidIntimaMediaThicknessGrade.Mild)
                .SetIntimaMediaThickeness(0.812)
                .SetPlaqueCharacter(CarotidPlaqueCharacter.Mixed)
                .SetPercentStenosisGrade(CarotidPercentStenosisGrade.LessThan50)
                .Build();
            
            var right = new CarotidUltrasoundResultBuilder()
                .SetImtGrade(CarotidIntimaMediaThicknessGrade.Mild)
                .SetIntimaMediaThickeness(0.791)
                .SetPlaqueCharacter(CarotidPlaqueCharacter.Mixed)
                .SetPercentStenosisGrade(CarotidPercentStenosisGrade.LessThan50)
                .Build();

            var us = CarotidUltrasound.Build(left, right);

            var result = new CarotidUltrasoundClassification(us);
            
            Assert.Equal(Laterality.Bilateral, result.Classification.Laterality);
        }
        
        [Fact]
        public void Classification_GivenBilateralButLeftWorseThanRightPlaque_ReturnsLeftWorseThanRight()
        {
            var left = new CarotidUltrasoundResultBuilder()
                .SetImtGrade(CarotidIntimaMediaThicknessGrade.Mild)
                .SetIntimaMediaThickeness(0.812)
                .SetPlaqueCharacter(CarotidPlaqueCharacter.Mixed)
                .SetPercentStenosisGrade(CarotidPercentStenosisGrade.LessThan50)
                .Build();
            
            var right = new CarotidUltrasoundResultBuilder()
                .SetImtGrade(CarotidIntimaMediaThicknessGrade.Mild)
                .SetIntimaMediaThickeness(0.791)
                .SetPlaqueCharacter(CarotidPlaqueCharacter.Mixed)
                .SetPercentStenosisGrade(CarotidPercentStenosisGrade.LessThan30)
                .Build();
            
            var us = CarotidUltrasound.Build(left, right);

            var result = new CarotidUltrasoundClassification(us);
            
            Assert.Equal(Laterality.Left, result.Classification.WorseSide);
        }

        [Fact]
        public void NullUltrasound_ThrowsAargumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new CarotidUltrasoundClassification(null));
        }
    }
}