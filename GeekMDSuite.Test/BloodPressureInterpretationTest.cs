using Xunit;
using Moq;

namespace GeekMDSuite.Test
{
    public class BloodPressureInterpretationTest
    {
        [Fact]
        void Stage_GivenPrehypertensionParameters_InterpretsPrehypertension()
        {
            var mockPatient = GenerateMockPatientWithSpecifiedBloodPressureParameters(_preHypertensionParameters);

            var bpStage = new BloodPressure(mockPatient.Object).Stage;
            
            Assert.Equal(BloodPressureStage.PreHypertension, bpStage);
        }


        [Fact]
        void Stage_GivenHypertensiveEmergencyParameters_InterpretsHypertensiveEmergency()
        {
            var mockPatient = GenerateMockPatientWithSpecifiedBloodPressureParameters(_hypertensiveEmergencyParameters);
            
            var bpStage = new BloodPressure(mockPatient.Object).Stage;
            
            Assert.Equal(BloodPressureStage.HypertensiveEmergency, bpStage);
        }
        [Fact]
        void Stage_GivenHypertensiveUrgencyParameters_DistinguishesHypertensiveUrgencyFromHypertensiveEmergency()
        {
            var mockPatient = GenerateMockPatientWithSpecifiedBloodPressureParameters(_hypertensiveUrgencyParameters);
            
            var bpStage = new BloodPressure(mockPatient.Object).Stage;
           
            Assert.Equal(BloodPressureStage.HypertensiveUrgency, bpStage);
        }
        // TODO: IMassMeasurement the interpreation string for key words which suggest a proper interpretation.
        
        private BloodPressureParameters _preHypertensionParameters = new BloodPressureParameters(133, 69, false);
        private BloodPressureParameters _hypertensiveEmergencyParameters = new BloodPressureParameters(200, 99, true);
        private BloodPressureParameters _hypertensiveUrgencyParameters = new BloodPressureParameters(200, 99, false);
        
        private static Mock<IPatient> GenerateMockPatientWithSpecifiedBloodPressureParameters(BloodPressureParameters parameters)
        {
            var mockPatient = new Mock<IPatient>();
            mockPatient.Setup(patient => patient.Vitals.BloodPressure)
                .Returns(parameters);
            mockPatient.Setup(patient => patient.BodyWeight.Kilograms)
                .Returns(105);
            mockPatient.Setup(patient => patient.Height.Meters)
                .Returns(1.72);
            return mockPatient;
        }
    }
}
