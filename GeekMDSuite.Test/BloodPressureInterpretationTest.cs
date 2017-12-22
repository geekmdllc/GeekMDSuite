using System;
using GeekMDSuite.Services.Interpretation;
using Xunit;
using static GeekMDSuite.Services.Interpretation.BloodPressureInterpretation.LowerLimits;

namespace GeekMDSuite.Test
{
    public class BloodPressureInterpretationTest
    {
        [Theory]
        [InlineData(Systolic.Normotension - 1, Diastolic.Normotension -1, BloodPressureStage.Hypotension)]
        [InlineData(Systolic.Normotension, Diastolic.Normotension, BloodPressureStage.Normotension)]
        [InlineData(Systolic.Normotension, Diastolic.Prehypertension, BloodPressureStage.PreHypertension)]
        [InlineData(Systolic.Prehypertension, Diastolic.Prehypertension, BloodPressureStage.PreHypertension)]
        [InlineData(Systolic.Stage1Hypertension, Diastolic.Stage1Hypertension, BloodPressureStage.Stage1Hypertension)]
        [InlineData(Systolic.Stage1Hypertension, Diastolic.Stage2Hypertension, BloodPressureStage.Stage2Hypertension)]
        [InlineData(Systolic.Stage2Hypertension, Diastolic.Stage2Hypertension, BloodPressureStage.Stage2Hypertension)]
        [InlineData(Systolic.Stage2Hypertension, Diastolic.HypertensiveUrgency, BloodPressureStage.HypertensiveUrgency)]
        [InlineData(Systolic.HypertensiveUrgency, Diastolic.HypertensiveUrgency, BloodPressureStage.HypertensiveUrgency, false)]
        [InlineData(Systolic.HypertensiveUrgency, Diastolic.HypertensiveUrgency, BloodPressureStage.HypertensiveEmergency, true)]
        
        public void Classification_GivenParameters_ReturnsProperStageClassification(int systolic, int diastolic, 
            BloodPressureStage expectedStage, bool organDamagePresent = false)
        {
            var bloodPressure = BloodPressure.Build(systolic, diastolic, organDamagePresent);
                
            var bpStage = new BloodPressureInterpretation(bloodPressure).Classification;
            
            Assert.Equal(expectedStage, bpStage);
        }
    
        [Fact]
        public void NullBloodPressure_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BloodPressureInterpretation(null));
        }
    }
}
