using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Builders;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Classification
{
    public class SpirometryClassificationTests
    {
        private readonly Patient _patient = PatientBuilder.Initialize()
            .SetDateOfBirth(1980, 11, 23)
            .SetGender(GenderIdentity.Male)
            .SetRace(Race.BlackOrAfricanAmerican)
            .BuildWithoutModelValidation();

        private readonly BodyComposition _bodyComposition = new BodyCompositionBuilder()
            .SetHeight(71)
            .SetWaist(35)
            .SetHips(41)
            .SetWeight(183)
            .Build();

        private const double ForcedVitalCapacity = 4.395;
        private const double RestrictedVitalCapacity = 3.4721;
        private const double Fev1 = 3.62;

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

            var result = new SpirometryClassification(spiromenty, _patient, _bodyComposition);

            Assert.Equal(SpirometryClassificationResult.ObstructionMild, result.Classification);
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

            var result = new SpirometryClassification(spiromenty, _patient, _bodyComposition);

            Assert.Equal(SpirometryClassificationResult.RestrictionMild, result.Classification);
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

            var result = new SpirometryClassification(spiromenty, _patient, _bodyComposition);

            Assert.Equal(SpirometryClassificationResult.MixedPattern, result.Classification);
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

            var result = new SpirometryClassification(spiromenty, _patient, _bodyComposition);

            Assert.Equal(SpirometryClassificationResult.ObstructionModeratelySevere, result.Classification);
        }

        [Fact]
        public void
            Classification_GivenModeratelySevereRestrictiveValues_ReturnsModeratelySevereRestrictionClassification()
        {
            var spiromenty = new SpirometryBuilder()
                .SetForcedExpiratoryVolume1Second(Fev1 * 0.59)
                .SetForcedVitalCapacity(RestrictedVitalCapacity * 0.59)
                .SetPeakExpiratoryFlow(8.94)
                .SetForcedExpiratoryFlow25To75(6.33)
                .SetForcedExpiratoryTime(6.2)
                .Build();

            var result = new SpirometryClassification(spiromenty, _patient, _bodyComposition);

            Assert.Equal(SpirometryClassificationResult.RestrictionModeratelySevere, result.Classification);
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

            var result = new SpirometryClassification(spiromenty, _patient, _bodyComposition);

            Assert.Equal(SpirometryClassificationResult.ObstructionModerate, result.Classification);
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

            var result = new SpirometryClassification(spiromenty, _patient, _bodyComposition);

            Assert.Equal(SpirometryClassificationResult.RestrictionModerate, result.Classification);
        }

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

            var result = new SpirometryClassification(spiromenty, _patient, _bodyComposition);

            Assert.Equal(SpirometryClassificationResult.Normal, result.Classification);
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

            var result = new SpirometryClassification(spiromenty, _patient, _bodyComposition);

            Assert.Equal(SpirometryClassificationResult.ObstructionSevere, result.Classification);
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

            var result = new SpirometryClassification(spiromenty, _patient, _bodyComposition);

            Assert.Equal(SpirometryClassificationResult.RestrictionSevere, result.Classification);
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

            var result = new SpirometryClassification(spiromenty, _patient, _bodyComposition);

            Assert.Equal(SpirometryClassificationResult.ObstructionVerySevere, result.Classification);
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

            var result = new SpirometryClassification(spiromenty, _patient, _bodyComposition);

            Assert.Equal(SpirometryClassificationResult.RestrictionVerySevere, result.Classification);
        }
    }
}