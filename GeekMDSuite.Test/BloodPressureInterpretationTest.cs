using GeekMDSuite.Services.Interpretation;
using Xunit;

namespace GeekMDSuite.Test
{
    public class BloodPressureInterpretationTest
    {
        [Fact]
        public void Stage_GivenPrehypertensionParameters_InterpretsPrehypertension()
        {
            var bpStage = new BloodPressureInterpretation(_preHypertensionParameters).Classification;
            
            Assert.Equal(BloodPressureStage.PreHypertension, bpStage);
        }


        [Fact]
        public void Stage_GivenHypertensiveEmergencyParameters_InterpretsHypertensiveEmergency()
        {
            var bpStage = new BloodPressureInterpretation(_hypertensiveEmergencyParameters).Classification;
            
            Assert.Equal(BloodPressureStage.HypertensiveEmergency, bpStage);
        }
        [Fact]
        public void Stage_GivenHypertensiveUrgencyParameters_DistinguishesHypertensiveUrgencyFromHypertensiveEmergency()
        {
            var bpStage = new BloodPressureInterpretation(_hypertensiveUrgencyParameters).Classification;
           
            Assert.Equal(BloodPressureStage.HypertensiveUrgency, bpStage);
        }
        
        private readonly BloodPressure _preHypertensionParameters = BloodPressure.Build(133, 69);
        private readonly BloodPressure _hypertensiveEmergencyParameters = BloodPressure.Build(200, 99, true);
        private readonly BloodPressure _hypertensiveUrgencyParameters = BloodPressure.Build(200, 99);
        
    }
}
