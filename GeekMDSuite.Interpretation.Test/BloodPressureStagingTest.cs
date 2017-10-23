using Xunit;

namespace GeekMDSuite.Interpretation.Test
{
    public class BloodPressureStagingTest
    {
        [Fact]
        void InterpretsPrehypertensionCorrectly()
        {
            var bpStage = BloodPressureStage.Interpret(133, 69, false);
            Assert.Equal(BloodPressureStages.PreHypertension, bpStage);
        }
        [Fact]
        void InterpretsHypertensiveEmergencyCorrectly()
        {
            var bpStage = BloodPressureStage.Interpret(200, 99, true);
            Assert.Equal(BloodPressureStages.HypertensiveEmergency, bpStage);
        }
        [Fact]
        void DistinguishesHypertensiveUrgencyFromHypertensiveEmergencyCorrectly()
        {
            var bpStage = BloodPressureStage.Interpret(200, 99, false);
            Assert.Equal(BloodPressureStages.HypertensiveUrgency, bpStage);
        }
    }
}