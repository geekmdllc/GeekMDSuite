using System;
using GeekMDSuite.Core.Procedures;

namespace GeekMDSuite.Core.Analytics.Classification
{
    public class AudiogramClassification : IClassifiable<AudiogramClassificationResult>
    {
        public AudiogramClassification(IAudiogram audiogram)
        {
            _left = audiogram.Left;
            _right = audiogram.Right;
        }

        private readonly IAudiogramDataset _left;
        private readonly IAudiogramDataset _right;
        
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
            return AudiogramDatasetClassification.HighestDatapoint(_left) >  AudiogramDatasetClassification.HighestDatapoint(_right);
        }

        private bool LeftAndRightSideAreEqual()
        {
            return AudiogramDatasetClassification.HighestDatapoint(_left) ==
                   AudiogramDatasetClassification.HighestDatapoint(_right);
        }

        private HearingLoss GetClassification()
        {
            return WorseSide() == Laterality.Left || WorseSide() == Laterality.Bilateral
                ? new AudiogramDatasetClassification(_left).Classification
                : new AudiogramDatasetClassification(_right).Classification;
        }
        private bool DifferenceLessThan10dB()
        {
            return Math.Abs(AudiogramDatasetClassification.HighestDatapoint(_left) - AudiogramDatasetClassification.HighestDatapoint(_right)) < 10.0f;
        }

    }
}