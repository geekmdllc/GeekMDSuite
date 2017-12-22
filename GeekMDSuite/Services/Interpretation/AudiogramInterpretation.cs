using System;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.Services.Interpretation
{
    public class AudiogramInterpretation : IInterpretable<AudiogramClassificationResult>
    {
        private readonly Audiogram _audiogram;

        public AudiogramInterpretation(Audiogram audiogram)
        {
            _audiogram = audiogram;
            _left = audiogram.Left;
            _right = audiogram.Right;
        }
        public InterpretationText Interpretation => throw new NotImplementedException();

        private readonly AudiogramDataset _left;
        private readonly AudiogramDataset _right;
        
        public AudiogramClassificationResult Classification => new AudiogramClassificationResult(
                GetClassification(),
                GetLaterality(),
                WorseSide());

        public override string ToString() => Classification.ToString();

        private Laterality GetLaterality()
        {
            return DifferenceLessThan10dB() ? Laterality.Bilateral : WorseSide();
        }

        private Laterality WorseSide()
        {
            if (LeftAndRightSideAreEqual()) return Laterality.Bilateral;
            return LeftIsWorseThanRight() ? Laterality.Left : Laterality.Right;
        }

        private bool LeftIsWorseThanRight()
        {
            return AudiogramDatasetInterpretation.HighestDatapoint(_left) >  AudiogramDatasetInterpretation.HighestDatapoint(_right);
        }

        private bool LeftAndRightSideAreEqual()
        {
            return AudiogramDatasetInterpretation.HighestDatapoint(_left) ==
                   AudiogramDatasetInterpretation.HighestDatapoint(_right);
        }

        private HearingLoss GetClassification()
        {
            return WorseSide() == Laterality.Left || WorseSide() == Laterality.Bilateral
                ? new AudiogramDatasetInterpretation(_left).Classification
                : new AudiogramDatasetInterpretation(_right).Classification;
        }
        private bool DifferenceLessThan10dB()
        {
            return Math.Abs(AudiogramDatasetInterpretation.HighestDatapoint(_left) - AudiogramDatasetInterpretation.HighestDatapoint(_right)) < 10.0f;
        }

    }
}