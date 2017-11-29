using Xunit;

namespace GeekMDSuite.Test
{
    public class BloodPressureInterpretationTest
    {
        [Fact]
        void Stage_GivenPrehypertensionParameters_InterpretsPrehypertension()
        {
            var bpStage = new BloodPressure(_preHypertensionParameters).Stage;
            
            Assert.Equal(BloodPressureStage.PreHypertension, bpStage);
        }


        [Fact]
        void Stage_GivenHypertensiveEmergencyParameters_InterpretsHypertensiveEmergency()
        {
            var bpStage = new BloodPressure(_hypertensiveEmergencyParameters).Stage;
            
            Assert.Equal(BloodPressureStage.HypertensiveEmergency, bpStage);
        }
        [Fact]
        void Stage_GivenHypertensiveUrgencyParameters_DistinguishesHypertensiveUrgencyFromHypertensiveEmergency()
        {
            var bpStage = new BloodPressure(_hypertensiveUrgencyParameters).Stage;
           
            Assert.Equal(BloodPressureStage.HypertensiveUrgency, bpStage);
        }
        // TODO: IMassMeasurement the interpreation string for key words which suggest a proper interpretation.
        
        private BloodPressureParameters _preHypertensionParameters = new BloodPressureParameters(133, 69, false);
        private BloodPressureParameters _hypertensiveEmergencyParameters = new BloodPressureParameters(200, 99, true);
        private BloodPressureParameters _hypertensiveUrgencyParameters = new BloodPressureParameters(200, 99, false);
        
    }
}
