using System;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.Services.Interpretation
{
    public class AudiogramInterpretation : IInterpretable<AudiogramClassificationResult>
    {
        public AudiogramInterpretation(Audiogram audiogram)
        {
            _left = audiogram.Left;
            _right = audiogram.Right;
        }
        public InterpretationText Interpretation => throw new NotImplementedException();

        private readonly AudiogramDataset _left;
        private readonly AudiogramDataset _right;
        
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
            return _left.HighestDatapoint > _right.HighestDatapoint ? Laterality.Left : Laterality.Right;
        }

        private HearingLoss GetClassification()
        {
            return WorstSide() == Laterality.Left || WorstSide() == Laterality.Bilateral
                ? _left.Classification
                : _right.Classification;
        }
        private bool DifferenceLessThan10dB()
        {
            return Math.Abs(_left.HighestDatapoint / 10.0f - _right.HighestDatapoint / 10.0f) < 1;
        }

    }
}