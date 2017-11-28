using System;

namespace GeekMDSuite
{
    public class AudiogramUnillateralInterpretation : IInterpretable
    {
        public Interpretation Interpretation => throw new NotImplementedException();

        private Interpretation _interpretation;

        public static HearingLossClassification Interpret(AudiogramSet set)
        {
            return AudiogramDataPointInterpretation.Interpret(set.HighestDatapoint).Flag;
        }

    }
}