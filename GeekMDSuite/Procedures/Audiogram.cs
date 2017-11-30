using System;
using GeekMDSuite.Tools;

namespace GeekMDSuite.Procedures
{
    public class Audiogram : IInterpretable
    {
        public Audiogram(AudiogramDataset left, AudiogramDataset right)
        {
            Left = left;
            Right = right;
        }
        public Interpretation Interpretation => throw new NotImplementedException();
        
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