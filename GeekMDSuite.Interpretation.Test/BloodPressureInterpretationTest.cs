using GeekMDSuite.Calculations;
using GeekMDSuite.Common.Models;
using GeekMDSuite.Interpretation.Vitals;
using Xunit;
using Moq;

namespace GeekMDSuite.Interpretation.Test
{
    public class BloodPressureInterpretationTest
    {
        [Fact]
        void Stage_GivenPrehypertensionParameters_InterpretsPrehypertension()
        {
            var personMock = new Mock<IPatient>();
            personMock.Setup(person => person.Vitals.BloodPressure)
                .Returns(_preHypertensionParameters);
            
            var bpStage = new BloodPressure(personMock.Object).Stage;
            
            Assert.Equal(BloodPressureStage.PreHypertension, bpStage);
        }
        [Fact]
        void Stage_GivenHypertensiveEmergencyParameters_InterpretsHypertensiveEmergency()
        {
            var personMock = new Mock<IPatient>();
            personMock.Setup(person => person.Vitals.BloodPressure)
                .Returns(_hypertensiveEmergencyParameters);
            
            var bpStage = new BloodPressure(personMock.Object).Stage;
            
            Assert.Equal(BloodPressureStage.HypertensiveEmergency, bpStage);
        }
        [Fact]
        void Stage_GivenHypertensiveUrgencyParameters_DistinguishesHypertensiveUrgencyFromHypertensiveEmergency()
        {
            var personMock = new Mock<IPatient>();
            personMock.Setup(person => person.Vitals.BloodPressure)
                .Returns(_hypertensiveUrgencyParameters);
            
            var bpStage = new BloodPressure(personMock.Object).Stage;
           
            Assert.Equal(BloodPressureStage.HypertensiveUrgency, bpStage);
        }
        // TODO: IMassMeasurement the interpreation string for key words which suggest a proper interpretation.
        
        private BloodPressureParameters _preHypertensionParameters = new BloodPressureParameters(133, 69, false);
        private BloodPressureParameters _hypertensiveEmergencyParameters = new BloodPressureParameters(200, 99, true);
        private BloodPressureParameters _hypertensiveUrgencyParameters = new BloodPressureParameters(200, 99, false);
    }
}