using Xunit;

namespace GeekMDSuite.Test
{
    public class AudiogramDatapointInterpretationTests
    {
        [Fact]
        public void Interpret_Given15_ReturnsNoHearingLoss()
        {
            var result = AudiogramDataPointInterpretation.Interpret(15).Flag;
            
            Assert.Equal(HearingLossClassification.None, result);
        }
        [Fact]
        public void Interpret_Given30_ReturnsMildHearingLoss()
        {
            var result = AudiogramDataPointInterpretation.Interpret(30).Flag;
            
            Assert.Equal(HearingLossClassification.Mild, result);
        }
        [Fact]
        public void Interpret_Given55_ReturnsModerateHearingLoss()
        {
            var result = AudiogramDataPointInterpretation.Interpret(55).Flag;
            
            Assert.Equal(HearingLossClassification.Moderate, result);
        }
        [Fact]
        public void Interpret_Given75_ReturnsSevereHearingLoss()
        {
            var result = AudiogramDataPointInterpretation.Interpret(75).Flag;
            
            Assert.Equal(HearingLossClassification.Severe, result);
        }
        [Fact]
        public void Interpret_Given95_ReturnsProfoundHearingLoss()
        {
            var result = AudiogramDataPointInterpretation.Interpret(95).Flag;
            
            Assert.Equal(HearingLossClassification.Profound, result);
        }
    }
}