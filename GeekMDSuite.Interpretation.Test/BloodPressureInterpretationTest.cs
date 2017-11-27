using GeekMDSuite.Calculations;
using GeekMDSuite.Common.Models;
using Xunit;

namespace GeekMDSuite.Interpretation.Test
{
    public class BloodPressureInterpretationTest
    {
        [Fact]
        void Stage_GivenPrehypertensionParameters_InterpretsPrehypertension()
        {
            
            var bpStage = new BloodPressureInterpretation().Stage(_preHypertensionParamters);
            Assert.Equal(BloodPressureStages.PreHypertension, bpStage);
        }
        [Fact]
        void Stage_GivenHypertensiveEmergencyParameters_InterpretsHypertensiveEmergency()
        {
            var bpStage = new BloodPressureInterpretation().Stage(_hypertensiveEmergencyParameters);
            Assert.Equal(BloodPressureStages.HypertensiveEmergency, bpStage);
        }
        [Fact]
        void Stage_GivenHypertensiveUrgencyParameters_DistinguishesHypertensiveUrgencyFromHypertensiveEmergency()
        {
            var bpStage = new BloodPressureInterpretation().Stage(_hypertensiveUrgencyParameters);
            Assert.Equal(BloodPressureStages.HypertensiveUrgency, bpStage);
        }
        // TODO: Test the interpreation string for key words which suggest a proper interpretation.
        
        private BloodPressureParameters _preHypertensionParamters = new BloodPressureParameters(133, 69, false);
        private BloodPressureParameters _hypertensiveEmergencyParameters = new BloodPressureParameters(200, 99, true);
        private BloodPressureParameters _hypertensiveUrgencyParameters = new BloodPressureParameters(200, 99, false);
    }
}