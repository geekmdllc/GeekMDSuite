using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Tools;

namespace GeekMDSuite.Services.Interpretation
{
    public class AudiogramInterpretation : IInterpretable<AudiogramClassificationResult>
    {
        public AudiogramInterpretation(Audiogram audiogram)
        {
            Left = audiogram.Left;
            Right = audiogram.Right;
        }
        public InterpretationText Interpretation => throw new NotImplementedException();
        
        public AudiogramDataset Left { get; }
        public AudiogramDataset Right { get; }
        
        public AudiogramClassificationResult Classification => new AudiogramClassificationResult(
                GetClassification(),
                GetLaterality(),
                WorstSide());
        
        private Laterality GetLaterality()
        {
            return DifferenceLessThan10dB() ? Laterality.Bilateral : WorstSide();
        }

        private Laterality WorstSide()
        {
            return Left.HighestDatapoint > Right.HighestDatapoint ? Laterality.Left : Laterality.Right;
        }

        private HearingLoss GetClassification()
        {
            return WorstSide() == Laterality.Left || WorstSide() == Laterality.Bilateral
                ? Left.Classification
                : Right.Classification;
        }
        private bool DifferenceLessThan10dB()
        {
            return Math.Abs(Left.HighestDatapoint / 10.0f - Right.HighestDatapoint / 10.0f) < 1;
        }

    }
}