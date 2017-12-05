using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using Xunit;

namespace GeekMDSuite.Test
{
    public class CarotidUltrasoundInterpretationTests
    {
        [Fact]
        public void Classification_GivenLeftSidedPlaque_ReturnsLeftWorseThanRightStenosis()
        {
            var left = new CarotidUltrasoundResult(
                0.812, CarotidIntimaMediaThicknessGrade.Mild, CarotidPlaqueCharacter.Mixed, CarotidPercentStenosisGrade.LessThan30);
            var right = new CarotidUltrasoundResult(
                0.791, CarotidIntimaMediaThicknessGrade.Normal, CarotidPlaqueCharacter.None, CarotidPercentStenosisGrade.None);
            
            var us = new CarotidUltrasound(left, right);

            var result = new CarotidUltrasoundInterpretation(us);
            
            Assert.Equal(Laterality.Left, result.Classification.WorseSide);
        }
        [Fact]
        public void Classification_GivenLeftSidedPlaque_ReturnsLeftLaterality()
        {
            var left = new CarotidUltrasoundResult(
                0.812, CarotidIntimaMediaThicknessGrade.Mild, CarotidPlaqueCharacter.Mixed, CarotidPercentStenosisGrade.LessThan30);
            var right = new CarotidUltrasoundResult(
                0.791, CarotidIntimaMediaThicknessGrade.Normal, CarotidPlaqueCharacter.None, CarotidPercentStenosisGrade.None);
            
            var us = new CarotidUltrasound(left, right);

            var result = new CarotidUltrasoundInterpretation(us);
            
            Assert.Equal(Laterality.Left, result.Classification.Laterality);
        }
        [Fact]
        public void Classification_GivenRightSidedPlaque_ReturnsRightWorseThanRightStenosis()
        {
            var left = new CarotidUltrasoundResult(
                0.812, CarotidIntimaMediaThicknessGrade.Normal, CarotidPlaqueCharacter.None, CarotidPercentStenosisGrade.None);
            var right = new CarotidUltrasoundResult(
                0.791, CarotidIntimaMediaThicknessGrade.Mild, CarotidPlaqueCharacter.Mixed, CarotidPercentStenosisGrade.LessThan50);
            
            var us = new CarotidUltrasound(left, right);

            var result = new CarotidUltrasoundInterpretation(us);
            
            Assert.Equal(Laterality.Right, result.Classification.WorseSide);
        }
        [Fact]
        public void Classification_GivenRightSidedPlaque_ReturnsRightLaterality()
        {
            var left = new CarotidUltrasoundResult(
                0.812, CarotidIntimaMediaThicknessGrade.Normal, CarotidPlaqueCharacter.None, CarotidPercentStenosisGrade.None);
            var right = new CarotidUltrasoundResult(
                0.791, CarotidIntimaMediaThicknessGrade.Mild, CarotidPlaqueCharacter.Mixed, CarotidPercentStenosisGrade.LessThan50);
            
            var us = new CarotidUltrasound(left, right);

            var result = new CarotidUltrasoundInterpretation(us);
            
            Assert.Equal(Laterality.Right, result.Classification.Laterality);
        }
        [Fact]
        public void Classification_GivenEqualPlaque_ReturnsBilateralLaterality()
        {
            var left = new CarotidUltrasoundResult(
                0.812, CarotidIntimaMediaThicknessGrade.Mild, CarotidPlaqueCharacter.Mixed, CarotidPercentStenosisGrade.LessThan50);
            var right = new CarotidUltrasoundResult(
                0.791, CarotidIntimaMediaThicknessGrade.Mild, CarotidPlaqueCharacter.Mixed, CarotidPercentStenosisGrade.LessThan50);
            
            var us = new CarotidUltrasound(left, right);

            var result = new CarotidUltrasoundInterpretation(us);
            
            Assert.Equal(Laterality.Bilateral, result.Classification.Laterality);
        }
        
        [Fact]
        public void Classification_GivenBilateralButLeftWorseThanRightPlaque_ReturnsLeftWorseThanRight()
        {
            var left = new CarotidUltrasoundResult(
                0.812, CarotidIntimaMediaThicknessGrade.Mild, CarotidPlaqueCharacter.Mixed, CarotidPercentStenosisGrade.LessThan50);
            var right = new CarotidUltrasoundResult(
                0.791, CarotidIntimaMediaThicknessGrade.Mild, CarotidPlaqueCharacter.Mixed, CarotidPercentStenosisGrade.LessThan30);
            
            var us = new CarotidUltrasound(left, right);

            var result = new CarotidUltrasoundInterpretation(us);
            
            Assert.Equal(Laterality.Left, result.Classification.WorseSide);
        }
    }
}