using System;

namespace GeekMDSuite
{
    public class AudiogramUnillateralInterpretation : IInterpretable
    {
        public Interpretation Interpretation => throw new NotImplementedException();

        public static HearingLossClassification Interpret(AudiogramSet set)
        {
            return AudiogramDataPointInterpretation.Interpret(set.HighestDatapoint).Flag;
        }

    }
}