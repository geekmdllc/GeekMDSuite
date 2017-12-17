using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using Xunit;

namespace GeekMDSuite.Test
{
    public class OcularPressureInterpretationTests
    {
        [Fact]
        public void Classify_GivenPressureInNormalRange_ReturnsNormal()
        {
            var ocularPressure = OcularPressure.Build(18,17);
            var classification = new OcularPressureInterpretation(ocularPressure).Classification;
            
            Assert.Equal(OcularPressureClassification.Normal, classification);
        }
        
        [Fact]
        public void Classify_GivenLeftEyePressureInHypertensiveRange_ReturnsOcularHypertension()
        {
            var ocularPressure = OcularPressure.Build(25,18);
            var classification = new OcularPressureInterpretation(ocularPressure).Classification;
            
            Assert.Equal(OcularPressureClassification.OcularHypertension, classification);
        }
        
        [Fact]
        public void Classify_GivenRightEyePressureInHypertensiveRange_ReturnsOcularHypertension()
        {
            var ocularPressure = OcularPressure.Build(17,30);
            var classification = new OcularPressureInterpretation(ocularPressure).Classification;
            
            Assert.Equal(OcularPressureClassification.OcularHypertension, classification);
        }
        
        [Fact]
        public void Classify_GivenBothEyePressureInHypertensiveRange_ReturnsOcularHypertension()
        {
            var ocularPressure = OcularPressure.Build(25,29);
            var classification = new OcularPressureInterpretation(ocularPressure).Classification;
            
            Assert.Equal(OcularPressureClassification.OcularHypertension, classification);
        }
    }
}