using GeekMDSuite.Interpretation.Procedures;
using Xunit;

namespace GeekMDSuite.Interpretation.Test
{
    public class BloodPressureInterpretationTest
    {
        [Fact]
        void InterpretsPrehypertensionCorrectly()
        {
            var bpStage = BloodPressureInterpretation.Interpret(133, 69, false);
            Assert.Equal(BloodPressureStages.PreHypertension, bpStage);
        }
        [Fact]
        void InterpretsHypertensiveEmergencyCorrectly()
        {
            var bpStage = BloodPressureInterpretation.Interpret(200, 99, true);
            Assert.Equal(BloodPressureStages.HypertensiveEmergency, bpStage);
        }
        [Fact]
        void DistinguishesHypertensiveUrgencyFromHypertensiveEmergencyCorrectly()
        {
            var bpStage = BloodPressureInterpretation.Interpret(200, 99, false);
            Assert.Equal(BloodPressureStages.HypertensiveUrgency, bpStage);
        }
    }
}