using System;
using GeekMDSuite.Analytics;
using GeekMDSuite.Analytics.Classification;
using Xunit;
using static GeekMDSuite.Analytics.Classification.BloodPressureClassification.LowerLimits;

namespace GeekMDSuite.Test
{
    public class BloodPressureInterpretationTest
    {
        [Theory]
        [InlineData(Systolic.Normal - 1, Diastolic.Normal -1, BloodPressureStage.Low)]
        [InlineData(Systolic.Normal, Diastolic.Normal -1, BloodPressureStage.Normal)]
        [InlineData(Systolic.Normal, Diastolic.Normal, BloodPressureStage.Normal)]
        [InlineData(Systolic.Elevated, Diastolic.Normal, BloodPressureStage.Elevated)]
        [InlineData(Systolic.Normal, Diastolic.Stage1Hypertension, BloodPressureStage.Stage1Hypertension)]
        [InlineData(Systolic.Stage1Hypertension, Diastolic.Normal - 1, BloodPressureStage.Stage1Hypertension)]
        [InlineData(Systolic.Stage1Hypertension, Diastolic.Normal, BloodPressureStage.Stage1Hypertension)]
        [InlineData(Systolic.Stage1Hypertension, Diastolic.Stage1Hypertension, BloodPressureStage.Stage1Hypertension)]
        [InlineData(Systolic.Stage1Hypertension, Diastolic.Stage2Hypertension, BloodPressureStage.Stage2Hypertension)]
        [InlineData(Systolic.Stage2Hypertension, Diastolic.Normal - 1, BloodPressureStage.Stage2Hypertension)]
        [InlineData(Systolic.Stage2Hypertension, Diastolic.Normal, BloodPressureStage.Stage2Hypertension)]
        [InlineData(Systolic.Stage2Hypertension, Diastolic.Stage1Hypertension, BloodPressureStage.Stage2Hypertension)]
        [InlineData(Systolic.Stage2Hypertension, Diastolic.Stage2Hypertension, BloodPressureStage.Stage2Hypertension)]
        [InlineData(Systolic.Normal -1, Diastolic.HypertensiveUrgency, BloodPressureStage.HypertensiveUrgency)]
        [InlineData(Systolic.Normal, Diastolic.HypertensiveUrgency, BloodPressureStage.HypertensiveUrgency)]
        [InlineData(Systolic.Elevated, Diastolic.HypertensiveUrgency, BloodPressureStage.HypertensiveUrgency)]
        [InlineData(Systolic.Stage1Hypertension, Diastolic.HypertensiveUrgency, BloodPressureStage.HypertensiveUrgency)]
        [InlineData(Systolic.Stage2Hypertension, Diastolic.HypertensiveUrgency, BloodPressureStage.HypertensiveUrgency)]
        [InlineData(Systolic.HypertensiveUrgency, Diastolic.Normal - 1, BloodPressureStage.HypertensiveUrgency, false)]
        [InlineData(Systolic.HypertensiveUrgency, Diastolic.Normal, BloodPressureStage.HypertensiveUrgency, false)]
        [InlineData(Systolic.HypertensiveUrgency, Diastolic.Stage1Hypertension, BloodPressureStage.HypertensiveUrgency, false)]
        [InlineData(Systolic.HypertensiveUrgency, Diastolic.Stage2Hypertension, BloodPressureStage.HypertensiveUrgency, false)]
        [InlineData(Systolic.HypertensiveUrgency, Diastolic.HypertensiveUrgency, BloodPressureStage.HypertensiveEmergency, true)]
        
        public void Classification_GivenParameters_ReturnsProperStageClassification(int systolic, int diastolic, 
            BloodPressureStage expectedStage, bool organDamagePresent = false)
        {
            var bloodPressure = BloodPressure.Build(systolic, diastolic, organDamagePresent);
                
            var bpStage = new BloodPressureClassification(bloodPressure).Classification;
            
            Assert.Equal(expectedStage, bpStage);
        }
    
        [Fact]
        public void NullBloodPressure_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BloodPressureClassification(null));
        }
    }
}
