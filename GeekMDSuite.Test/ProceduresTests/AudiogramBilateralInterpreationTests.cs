using Xunit;

namespace GeekMDSuite.Test.ProceduresTests
{
    public class AudiogramBilateralInterpreationTests
    {
        [Fact]
        public void Interpret_GivenLeftSideWorseAt55db_ReturnsLeftSidedModerateHearingLoss()
        {
            var result = AudiogramBilateralInterpreation.Interpret(new Audiogram{
                    Left = new AudiogramSet
                    {
                        F1000 = AudiogramDataPointInterpretation.Interpret(55)
                    },
                    Right = new AudiogramSet
                    {
                        F2000 = AudiogramDataPointInterpretation.Interpret(35)
                    }
                }
            );
            
            Assert.Equal(Laterality.Left, result.Laterality);
            Assert.Equal(HearingLossClassification.Moderate, result.Classification);
        }
        
        [Fact]
        public void Interpret_GivenRightSideWorseAt95db_ReturnsRightSidedProfoundHearingLoss()
        {
            var result = AudiogramBilateralInterpreation.Interpret(new Audiogram{
                    Left = new AudiogramSet
                    {
                        F1000 = AudiogramDataPointInterpretation.Interpret(55)
                    },
                    Right = new AudiogramSet
                    {
                        F2000 = AudiogramDataPointInterpretation.Interpret(95)
                    }
                }
            );
            
            Assert.Equal(Laterality.Right, result.Laterality);
            Assert.Equal(HearingLossClassification.Profound, result.Classification);
        }
        
        [Fact]
        public void Interpret_GivenLeftAndRightWithin10dBOf70dB_ReturnsBilateralSevereHearingLoss()
        {
            var result = AudiogramBilateralInterpreation.Interpret(new Audiogram{
                    Left = new AudiogramSet
                    {
                        F1000 = AudiogramDataPointInterpretation.Interpret(66)
                    },
                    Right = new AudiogramSet
                    {
                        F2000 = AudiogramDataPointInterpretation.Interpret(74)
                    }
                }
            );
            
            Assert.Equal(Laterality.Bilateral, result.Laterality);
            Assert.Equal(HearingLossClassification.Severe, result.Classification);
        }
    }
}