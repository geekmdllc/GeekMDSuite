using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using GeekMDSuite.Tools.MeasurementUnits;
using Xunit;

namespace GeekMDSuite.Test
{
    public class SpirometryTests
    {
        //TODO: Test cases for mixed and all restriction cases
        [Fact]
        public void Classification_GivenNormalValues_ReturnsNormalClassification()
        {
            var spiromenty = new Spirometry(_forcedVitalCapacity * 0.71, _forcedVitalCapacity, 8.94, 6.33, 6.2);
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.Normal, result.Classification);
        }
        
        [Fact]
        public void Classification_GivenMildObstructionValues_ReturnsMildObstructionClassification()
        {
            var spiromenty = new Spirometry(_fev1 * 0.71, _forcedVitalCapacity, 8.94, 6.33, 6.2);
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.ObstructionMild, result.Classification);
        }
        [Fact]
        public void Classification_GivenModerateObstructionValues_ReturnsModerateClassification()
        {
            var spiromenty = new Spirometry(_fev1 * 0.69, _forcedVitalCapacity, 8.94, 6.33, 6.2);
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.ObstructionModerate, result.Classification);
        }
        [Fact]
        public void Classification_GivenModeratelySevereObstructionValues_ReturnsModeratelySevereClassification()
        {
            var spiromenty = new Spirometry(_fev1 * 0.59, _forcedVitalCapacity, 8.94, 6.33, 6.2);
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.ObstructionModeratelySevere, result.Classification);
        }
        [Fact]
        public void Classification_GivenSevereObstructionValues_ReturnsSevereClassification()
        {
            var spiromenty = new Spirometry(_fev1 * 0.49, _forcedVitalCapacity, 8.94, 6.33, 6.2);
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.ObstructionSevere, result.Classification);
        }
        
        [Fact]
        public void Classification_GivenVerySevereObstructionValues_ReturnsVerySevereClassification()
        {
            var spiromenty = new Spirometry(_fev1 * 0.34, _forcedVitalCapacity, 8.94, 6.33, 6.2);
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.ObstructionVerySevere, result.Classification);
        }
        
        [Fact]
        public void Classification_GivenMixedPattern_ReturnsMixedPatternClassification()
        {
            var spiromenty = new Spirometry(_restrictedVitalCapacity * 0.69, _restrictedVitalCapacity, 8.94, 6.33, 6.2);
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.RestrictionMild, result.Classification);
        }
        
        [Fact]
        public void Classification_GivenMildRestrictiveValues_ReturnsMildRestrictionClassification()
        {
            var spiromenty = new Spirometry(_restrictedVitalCapacity * 0.71, _restrictedVitalCapacity, 8.94, 6.33, 6.2);
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.RestrictionMild, result.Classification);
        }
        
        private readonly Patient _patient = new Patient(
            new Name("Jim", "Joe", "Bob"), 
            new DateTime(1980, 11, 23), 
            new Gender(GenderIdentity.Male), 
            Race.BlackOrAfricanAmerican, 
            "1234" );
        private readonly BodyComposition _bodyComposition = new BodyComposition(
            new Height(71), 
            new Waist(35), 
            new Hips(41), 
            new Weight(183));
        
        private double _forcedVitalCapacity = 4.395;
        private double _restrictedVitalCapacity = 3.4721;
        private double _fev1 = 3.62;
    }
}