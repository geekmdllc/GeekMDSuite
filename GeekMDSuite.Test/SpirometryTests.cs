using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using GeekMDSuite.Tools.MeasurementUnits;
using Xunit;

namespace GeekMDSuite.Test
{
    public class SpirometryTests
    {
        //TODO: IshiharaSixPlateInterpretation_GivenAllNormal_ReturnsNormalVision cases for mixed and all restriction cases
        [Fact]
        public void Classification_GivenNormalValues_ReturnsNormalClassification()
        {
            var spiromenty = new Spirometry(ForcedVitalCapacity * 0.71, ForcedVitalCapacity, 8.94, 6.33, 6.2);
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.Normal, result.Classification);
        }
        
        [Fact]
        public void Classification_GivenMildObstructionValues_ReturnsMildObstructionClassification()
        {
            var spiromenty = new Spirometry(Fev1 * 0.71, ForcedVitalCapacity, 8.94, 6.33, 6.2);
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.ObstructionMild, result.Classification);
        }
        [Fact]
        public void Classification_GivenModerateObstructionValues_ReturnsModerateClassification()
        {
            var spiromenty = new Spirometry(Fev1 * 0.69, ForcedVitalCapacity, 8.94, 6.33, 6.2);
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.ObstructionModerate, result.Classification);
        }
        [Fact]
        public void Classification_GivenModeratelySevereObstructionValues_ReturnsModeratelySevereClassification()
        {
            var spiromenty = new Spirometry(Fev1 * 0.59, ForcedVitalCapacity, 8.94, 6.33, 6.2);
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.ObstructionModeratelySevere, result.Classification);
        }
        [Fact]
        public void Classification_GivenSevereObstructionValues_ReturnsSevereClassification()
        {
            var spiromenty = new Spirometry(Fev1 * 0.49, ForcedVitalCapacity, 8.94, 6.33, 6.2);
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.ObstructionSevere, result.Classification);
        }
        
        [Fact]
        public void Classification_GivenVerySevereObstructionValues_ReturnsVerySevereClassification()
        {
            var spiromenty = new Spirometry(Fev1 * 0.34, ForcedVitalCapacity, 8.94, 6.33, 6.2);
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.ObstructionVerySevere, result.Classification);
        }
        
        [Fact]
        public void Classification_GivenMixedPattern_ReturnsMixedPatternClassification()
        {
            var spiromenty = new Spirometry(RestrictedVitalCapacity * 0.69, RestrictedVitalCapacity, 8.94, 6.33, 6.2);
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.MixedPattern, result.Classification);
        }
        
        [Fact]
        public void Classification_GivenMildRestrictiveValues_ReturnsMildRestrictionClassification()
        {
            var spiromenty = new Spirometry(Fev1 * 0.71, RestrictedVitalCapacity * 0.71, 8.94, 6.33, 6.2);
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.RestrictionMild, result.Classification);
        }
        
        [Fact]
        public void Classification_GivenModerateRestrictiveValues_ReturnsModerateRestrictionClassification()
        {
            var spiromenty = new Spirometry(Fev1 * 0.69, RestrictedVitalCapacity * 0.69, 8.94, 6.33, 6.2);
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.RestrictionModerate, result.Classification);
        }
        
        [Fact]
        public void Classification_GivenModeratelySevereRestrictiveValues_ReturnsModeratelySevereRestrictionClassification()
        {
            var spiromenty = new Spirometry(Fev1 * 0.59, RestrictedVitalCapacity * 0.59, 8.94, 6.33, 6.2);
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.RestrictionModeratelySevere, result.Classification);
        }
        
        [Fact]
        public void Classification_GivenSevereRestrictiveValues_ReturnsSevereRestrictionClassification()
        {
            var spiromenty = new Spirometry(Fev1 * 0.49, RestrictedVitalCapacity * 0.49, 8.94, 6.33, 6.2);
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.RestrictionSevere, result.Classification);
        }
        
        [Fact]
        public void Classification_GivenVerySevereRestrictiveValues_ReturnsVerySevereRestrictionClassification()
        {
            var spiromenty = new Spirometry(Fev1 * 0.34, RestrictedVitalCapacity * 0.34, 8.94, 6.33, 6.2);
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.RestrictionVerySevere, result.Classification);
        }
        
        private readonly Patient _patient = new Patient(
            Name.Create("Jim", "Bob", "Joe"), 
            new DateTime(1980, 11, 23), 
            Gender.Create(GenderIdentity.Male), 
            Race.BlackOrAfricanAmerican, 
            "1234" );

        private readonly BodyComposition _bodyComposition = new BodyCompositionBuilder()
            .SetHeight(71)
            .SetWaist(35)
            .SetHips(41)
            .SetWeight(183)
            .Build();

        private const double ForcedVitalCapacity = 4.395;
        private const double RestrictedVitalCapacity = 3.4721;
        private const double Fev1 = 3.62;
    }
}