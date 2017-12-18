using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using Xunit;

namespace GeekMDSuite.Test
{
    public class SpirometryTests
    {
        //TODO: IshiharaSixPlateInterpretation_GivenAllNormal_ReturnsNormalVision cases for mixed and all restriction cases
        [Fact]
        public void Classification_GivenNormalValues_ReturnsNormalClassification()
        {
            var spiromenty = new SpirometryBuilder()
                .SetForcedExpiratoryVolume1Second(ForcedVitalCapacity * 0.71)
                .SetForcedVitalCapacity(ForcedVitalCapacity)
                .SetPeakExpiratoryFlow(8.94)
                .SetForcedExpiratoryFlow25To75(6.33)
                .SetForcedExpiratoryTime(6.2)
                .Build();

            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.Normal, result.Classification);
        }
        
        [Fact]
        public void Classification_GivenMildObstructionValues_ReturnsMildObstructionClassification()
        {
            var spiromenty = new SpirometryBuilder()
                .SetForcedExpiratoryVolume1Second(Fev1 * 0.71)
                .SetForcedVitalCapacity(ForcedVitalCapacity)
                .SetPeakExpiratoryFlow(8.94)
                .SetForcedExpiratoryFlow25To75(6.33)
                .SetForcedExpiratoryTime(6.2)
                .Build();
            
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.ObstructionMild, result.Classification);
        }
        [Fact]
        public void Classification_GivenModerateObstructionValues_ReturnsModerateClassification()
        {
            var spiromenty = new SpirometryBuilder()
                .SetForcedExpiratoryVolume1Second(Fev1 * 0.69)
                .SetForcedVitalCapacity(ForcedVitalCapacity)
                .SetPeakExpiratoryFlow(8.94)
                .SetForcedExpiratoryFlow25To75(6.33)
                .SetForcedExpiratoryTime(6.2)
                .Build();
            
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.ObstructionModerate, result.Classification);
        }
        [Fact]
        public void Classification_GivenModeratelySevereObstructionValues_ReturnsModeratelySevereClassification()
        {
            var spiromenty = new SpirometryBuilder()
                .SetForcedExpiratoryVolume1Second(Fev1 * 0.59)
                .SetForcedVitalCapacity(ForcedVitalCapacity)
                .SetPeakExpiratoryFlow(8.94)
                .SetForcedExpiratoryFlow25To75(6.33)
                .SetForcedExpiratoryTime(6.2)
                .Build();
            
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.ObstructionModeratelySevere, result.Classification);
        }
        [Fact]
        public void Classification_GivenSevereObstructionValues_ReturnsSevereClassification()
        {
            var spiromenty = new SpirometryBuilder()
                .SetForcedExpiratoryVolume1Second(Fev1 * 0.49)
                .SetForcedVitalCapacity(ForcedVitalCapacity)
                .SetPeakExpiratoryFlow(8.94)
                .SetForcedExpiratoryFlow25To75(6.33)
                .SetForcedExpiratoryTime(6.2)
                .Build();
            
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.ObstructionSevere, result.Classification);
        }
        
        [Fact]
        public void Classification_GivenVerySevereObstructionValues_ReturnsVerySevereClassification()
        {
            var spiromenty = new SpirometryBuilder()
                .SetForcedExpiratoryVolume1Second(Fev1 * 0.34)
                .SetForcedVitalCapacity(ForcedVitalCapacity)
                .SetPeakExpiratoryFlow(8.94)
                .SetForcedExpiratoryFlow25To75(6.33)
                .SetForcedExpiratoryTime(6.2)
                .Build();
            
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.ObstructionVerySevere, result.Classification);
        }
        
        [Fact]
        public void Classification_GivenMixedPattern_ReturnsMixedPatternClassification()
        {
            var spiromenty = new SpirometryBuilder()
                .SetForcedExpiratoryVolume1Second(RestrictedVitalCapacity * 0.69)
                .SetForcedVitalCapacity(RestrictedVitalCapacity)
                .SetPeakExpiratoryFlow(8.94)
                .SetForcedExpiratoryFlow25To75(6.33)
                .SetForcedExpiratoryTime(6.2)
                .Build();
            
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.MixedPattern, result.Classification);
        }
        
        [Fact]
        public void Classification_GivenMildRestrictiveValues_ReturnsMildRestrictionClassification()
        {
            var spiromenty = new SpirometryBuilder()
                .SetForcedExpiratoryVolume1Second(Fev1 * 0.71)
                .SetForcedVitalCapacity(RestrictedVitalCapacity * 0.71)
                .SetPeakExpiratoryFlow(8.94)
                .SetForcedExpiratoryFlow25To75(6.33)
                .SetForcedExpiratoryTime(6.2)
                .Build();
            
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.RestrictionMild, result.Classification);
        }
        
        [Fact]
        public void Classification_GivenModerateRestrictiveValues_ReturnsModerateRestrictionClassification()
        {
            var spiromenty = new SpirometryBuilder()
                .SetForcedExpiratoryVolume1Second(Fev1 * 0.69)
                .SetForcedVitalCapacity(RestrictedVitalCapacity * 0.69)
                .SetPeakExpiratoryFlow(8.94)
                .SetForcedExpiratoryFlow25To75(6.33)
                .SetForcedExpiratoryTime(6.2)
                .Build();
            
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.RestrictionModerate, result.Classification);
        }
        
        [Fact]
        public void Classification_GivenModeratelySevereRestrictiveValues_ReturnsModeratelySevereRestrictionClassification()
        {
            var spiromenty = new SpirometryBuilder()
                .SetForcedExpiratoryVolume1Second(Fev1 * 0.59)
                .SetForcedVitalCapacity(RestrictedVitalCapacity * 0.59)
                .SetPeakExpiratoryFlow(8.94)
                .SetForcedExpiratoryFlow25To75(6.33)
                .SetForcedExpiratoryTime(6.2)
                .Build();
            
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.RestrictionModeratelySevere, result.Classification);
        }
        
        [Fact]
        public void Classification_GivenSevereRestrictiveValues_ReturnsSevereRestrictionClassification()
        {
            var spiromenty = new SpirometryBuilder()
                .SetForcedExpiratoryVolume1Second(Fev1 * 0.49)
                .SetForcedVitalCapacity(RestrictedVitalCapacity * 0.49)
                .SetPeakExpiratoryFlow(8.94)
                .SetForcedExpiratoryFlow25To75(6.33)
                .SetForcedExpiratoryTime(6.2)
                .Build();
            
            var result = new SpirometryInterpretation(spiromenty, _patient, _bodyComposition);
            
            Assert.Equal(SpirometryClassification.RestrictionSevere, result.Classification);
        }
        
        [Fact]
        public void Classification_GivenVerySevereRestrictiveValues_ReturnsVerySevereRestrictionClassification()
        {
            var spiromenty = new SpirometryBuilder()
                .SetForcedExpiratoryVolume1Second(Fev1 * 0.34)
                .SetForcedVitalCapacity(RestrictedVitalCapacity * 0.34)
                .SetPeakExpiratoryFlow(8.94)
                .SetForcedExpiratoryFlow25To75(6.33)
                .SetForcedExpiratoryTime(6.2)
                .Build();
            
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