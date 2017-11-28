using GeekMDSuite.Models;
using GeekMDSuite.Services;
using GeekMDSuite.Interpretation.Procedures;
using Xunit;

namespace GeekMDSuite.Interpretation.Test.ProceduresTests
{
    public class AudiogramUnilateralInterpretationTests
    {
        [Fact]
        public void Interpret_GivenMax75dBLossAt3000Hz_ReturnsSevereHearingLoss()
        {
            var result = AudiogramUnillateralInterpretation.Interpret(new AudiogramSet
            {
                F250 = AudiogramDataPointInterpretation.Interpret(30),
                F500 = AudiogramDataPointInterpretation.Interpret(30),
                F1000 = AudiogramDataPointInterpretation.Interpret(30),
                F2000 = AudiogramDataPointInterpretation.Interpret(30),
                F3000 = AudiogramDataPointInterpretation.Interpret(75),
                F4000 = AudiogramDataPointInterpretation.Interpret(30),
                F6000 = AudiogramDataPointInterpretation.Interpret(30),
                F8000 = AudiogramDataPointInterpretation.Interpret(30),
            });
            
            Assert.Equal(HearingLossClassification.Severe, result);
        }
        
        [Fact]
        public void Interpret_GivenMax15dBAt1000Hz_ReturnsNoHearingLoss()
        {
            var result = AudiogramUnillateralInterpretation.Interpret(new AudiogramSet
            {
                F250 = AudiogramDataPointInterpretation.Interpret(10),
                F500 = AudiogramDataPointInterpretation.Interpret(10),
                F1000 = AudiogramDataPointInterpretation.Interpret(15),
                F2000 = AudiogramDataPointInterpretation.Interpret(10),
                F3000 = AudiogramDataPointInterpretation.Interpret(10),
                F4000 = AudiogramDataPointInterpretation.Interpret(10),
                F6000 = AudiogramDataPointInterpretation.Interpret(10),
                F8000 = AudiogramDataPointInterpretation.Interpret(10),
            });
            
            Assert.Equal(HearingLossClassification.None, result);
        }
    }
}