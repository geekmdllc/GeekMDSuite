using GeekMDSuite.Calculations;
using GeekMDSuite.Common;
using GeekMDSuite.Common.Models;
using Xunit;

namespace GeekMDSuite.Interpretation.Test
{
    public class BloodPressureInterpretationTest
    {
        [Fact]
        void InterpretsPrehypertensionCorrectly()
        {
            var bpStage = BloodPressure.Interpret(new BloodPressureParameters(133, 69, false));
            Assert.Equal(BloodPressureStages.PreHypertension, bpStage);
        }
        [Fact]
        void InterpretsHypertensiveEmergencyCorrectly()
        {
            var bpStage = BloodPressure.Interpret(new BloodPressureParameters(200, 99, true));
            Assert.Equal(BloodPressureStages.HypertensiveEmergency, bpStage);
        }
        [Fact]
        void DistinguishesHypertensiveUrgencyFromHypertensiveEmergencyCorrectly()
        {
            var bpStage = BloodPressure.Interpret(new BloodPressureParameters(200, 99, false));
            Assert.Equal(BloodPressureStages.HypertensiveUrgency, bpStage);
        }
    }
}