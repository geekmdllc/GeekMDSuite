using GeekMDSuite.Common.Models;
using GeekMDSuite.Common.Services;

namespace GeekMDSuite.Interpretation.Procedures
{
    public static class AudiogramUnillateralInterpretation
    {
        public static HearingLossClassification Interpret(AudiogramSet set)
        {
            return AudiogramDataPointInterpretation.Interpret(set.HighestDatapoint).Flag;
        }
    }
}