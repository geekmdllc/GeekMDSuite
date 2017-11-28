using System;
using GeekMDSuite.Models;
using GeekMDSuite.Services;

namespace GeekMDSuite.Interpretation.Procedures
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