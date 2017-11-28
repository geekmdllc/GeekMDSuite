﻿using System;
using GeekMDSuite;
using GeekMDSuite.Models;
using GeekMDSuite.Services;

namespace GeekMDSuite.Interpretation.Procedures
{
    public class AudiogramBilateralInterpreation : IInterpretable
    {
        public Interpretation Interpretation => throw new NotImplementedException();

        private Interpretation _interpretation;

        public static AudiogramInterpretationResult Interpret(Audiogram audiogram)
        {
            return new AudiogramInterpretationResult
            {
                Classification = GetClassification(audiogram),
                Laterality = GetLaterality(audiogram),
                WorstSide = WorstSide(audiogram)
            };
        }

        private static Laterality GetLaterality(Audiogram audiogram)
        {
            return DifferenceLessThan10dB(audiogram) ? Laterality.Bilateral : WorstSide(audiogram);
        }

        private static Laterality WorstSide(Audiogram audiogram)
        {
            return audiogram.Left.HighestDatapoint > audiogram.Right.HighestDatapoint ? Laterality.Left : Laterality.Right;
        }

        private static HearingLossClassification GetClassification(Audiogram audiogram)
        {
            return WorstSide(audiogram) == Laterality.Left || WorstSide(audiogram) == Laterality.Bilateral
                ? AudiogramUnillateralInterpretation.Interpret(audiogram.Left)
                : AudiogramUnillateralInterpretation.Interpret(audiogram.Right);
        }
        private static bool DifferenceLessThan10dB(Audiogram audiogram)
        {
            return Math.Abs(audiogram.Left.HighestDatapoint / 10.0f - audiogram.Right.HighestDatapoint / 10.0f) < 1;
        }

    }
}