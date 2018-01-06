using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Models;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Classification
{
    public class BloodPressureInterpretationTest
    {
        [Theory]
        [InlineData(BloodPressureClassification.LowerLimits.Systolic.Normal - 1, BloodPressureClassification.LowerLimits.Diastolic.Normal -1, BloodPressureStage.Low)]
        [InlineData(BloodPressureClassification.LowerLimits.Systolic.Normal, BloodPressureClassification.LowerLimits.Diastolic.Normal -1, BloodPressureStage.Normal)]
        [InlineData(BloodPressureClassification.LowerLimits.Systolic.Normal, BloodPressureClassification.LowerLimits.Diastolic.Normal, BloodPressureStage.Normal)]
        [InlineData(BloodPressureClassification.LowerLimits.Systolic.Elevated, BloodPressureClassification.LowerLimits.Diastolic.Normal, BloodPressureStage.Elevated)]
        [InlineData(BloodPressureClassification.LowerLimits.Systolic.Normal, BloodPressureClassification.LowerLimits.Diastolic.Stage1Hypertension, BloodPressureStage.Stage1Hypertension)]
        [InlineData(BloodPressureClassification.LowerLimits.Systolic.Stage1Hypertension, BloodPressureClassification.LowerLimits.Diastolic.Normal - 1, BloodPressureStage.Stage1Hypertension)]
        [InlineData(BloodPressureClassification.LowerLimits.Systolic.Stage1Hypertension, BloodPressureClassification.LowerLimits.Diastolic.Normal, BloodPressureStage.Stage1Hypertension)]
        [InlineData(BloodPressureClassification.LowerLimits.Systolic.Stage1Hypertension, BloodPressureClassification.LowerLimits.Diastolic.Stage1Hypertension, BloodPressureStage.Stage1Hypertension)]
        [InlineData(BloodPressureClassification.LowerLimits.Systolic.Stage1Hypertension, BloodPressureClassification.LowerLimits.Diastolic.Stage2Hypertension, BloodPressureStage.Stage2Hypertension)]
        [InlineData(BloodPressureClassification.LowerLimits.Systolic.Stage2Hypertension, BloodPressureClassification.LowerLimits.Diastolic.Normal - 1, BloodPressureStage.Stage2Hypertension)]
        [InlineData(BloodPressureClassification.LowerLimits.Systolic.Stage2Hypertension, BloodPressureClassification.LowerLimits.Diastolic.Normal, BloodPressureStage.Stage2Hypertension)]
        [InlineData(BloodPressureClassification.LowerLimits.Systolic.Stage2Hypertension, BloodPressureClassification.LowerLimits.Diastolic.Stage1Hypertension, BloodPressureStage.Stage2Hypertension)]
        [InlineData(BloodPressureClassification.LowerLimits.Systolic.Stage2Hypertension, BloodPressureClassification.LowerLimits.Diastolic.Stage2Hypertension, BloodPressureStage.Stage2Hypertension)]
        [InlineData(BloodPressureClassification.LowerLimits.Systolic.Normal -1, BloodPressureClassification.LowerLimits.Diastolic.HypertensiveUrgency, BloodPressureStage.HypertensiveUrgency)]
        [InlineData(BloodPressureClassification.LowerLimits.Systolic.Normal, BloodPressureClassification.LowerLimits.Diastolic.HypertensiveUrgency, BloodPressureStage.HypertensiveUrgency)]
        [InlineData(BloodPressureClassification.LowerLimits.Systolic.Elevated, BloodPressureClassification.LowerLimits.Diastolic.HypertensiveUrgency, BloodPressureStage.HypertensiveUrgency)]
        [InlineData(BloodPressureClassification.LowerLimits.Systolic.Stage1Hypertension, BloodPressureClassification.LowerLimits.Diastolic.HypertensiveUrgency, BloodPressureStage.HypertensiveUrgency)]
        [InlineData(BloodPressureClassification.LowerLimits.Systolic.Stage2Hypertension, BloodPressureClassification.LowerLimits.Diastolic.HypertensiveUrgency, BloodPressureStage.HypertensiveUrgency)]
        [InlineData(BloodPressureClassification.LowerLimits.Systolic.HypertensiveUrgency, BloodPressureClassification.LowerLimits.Diastolic.Normal - 1, BloodPressureStage.HypertensiveUrgency, false)]
        [InlineData(BloodPressureClassification.LowerLimits.Systolic.HypertensiveUrgency, BloodPressureClassification.LowerLimits.Diastolic.Normal, BloodPressureStage.HypertensiveUrgency, false)]
        [InlineData(BloodPressureClassification.LowerLimits.Systolic.HypertensiveUrgency, BloodPressureClassification.LowerLimits.Diastolic.Stage1Hypertension, BloodPressureStage.HypertensiveUrgency, false)]
        [InlineData(BloodPressureClassification.LowerLimits.Systolic.HypertensiveUrgency, BloodPressureClassification.LowerLimits.Diastolic.Stage2Hypertension, BloodPressureStage.HypertensiveUrgency, false)]
        [InlineData(BloodPressureClassification.LowerLimits.Systolic.HypertensiveUrgency, BloodPressureClassification.LowerLimits.Diastolic.HypertensiveUrgency, BloodPressureStage.HypertensiveEmergency, true)]
        
        public void Classification_GivenParameters_ReturnsProperStageClassification(int systolic, int diastolic, 
            BloodPressureStage expectedStage, bool organDamagePresent = false)
        {
            var bloodPressure = BloodPressure.Build(systolic, diastolic, organDamagePresent);
                
            var bpClassification = new BloodPressureClassification(bloodPressure).Classification;
            
            Assert.Equal(expectedStage, bpClassification.Stage);
        }
    
        [Fact]
        public void NullBloodPressure_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BloodPressureClassification(null));
        }
    }
}
