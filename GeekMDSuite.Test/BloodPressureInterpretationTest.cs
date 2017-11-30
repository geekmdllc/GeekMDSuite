using GeekMDSuite.Services.Interpretation;
using Xunit;

namespace GeekMDSuite.Test
{
    public class BloodPressureInterpretationTest
    {
        [Fact]
        void Stage_GivenPrehypertensionParameters_InterpretsPrehypertension()
        {
            var bpStage = new BloodPressureInterpretation(_preHypertensionParameters).Stage;
            
            Assert.Equal(BloodPressureStage.PreHypertension, bpStage);
        }


        [Fact]
        void Stage_GivenHypertensiveEmergencyParameters_InterpretsHypertensiveEmergency()
        {
            var bpStage = new BloodPressureInterpretation(_hypertensiveEmergencyParameters).Stage;
            
            Assert.Equal(BloodPressureStage.HypertensiveEmergency, bpStage);
        }
        [Fact]
        void Stage_GivenHypertensiveUrgencyParameters_DistinguishesHypertensiveUrgencyFromHypertensiveEmergency()
        {
            var bpStage = new BloodPressureInterpretation(_hypertensiveUrgencyParameters).Stage;
           
            Assert.Equal(BloodPressureStage.HypertensiveUrgency, bpStage);
        }
        // TODO: IMassMeasurement the interpreation string for key words which suggest a proper interpretation.
        
        private BloodPressure _preHypertensionParameters = new BloodPressure(133, 69, false);
        private BloodPressure _hypertensiveEmergencyParameters = new BloodPressure(200, 99, true);
        private BloodPressure _hypertensiveUrgencyParameters = new BloodPressure(200, 99, false);
        
    }
}
