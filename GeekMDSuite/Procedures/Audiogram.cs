using System;

namespace GeekMDSuite.Procedures
{
    public class Audiogram : IAudiogram
    {
        private Audiogram (IAudiogramDataset left, IAudiogramDataset right)
        {
            Left = left ?? throw new ArgumentNullException(nameof(left));
            Right = right ?? throw new ArgumentNullException(nameof(right));
        }

        public IAudiogramDataset Right { get; }
        public IAudiogramDataset Left { get; }

        public static Audiogram Build(IAudiogramDataset left, IAudiogramDataset right) => new Audiogram(left, right);

        public override string ToString()
        {
            return $"Left: {Left}\nRight:{Right}";
        }
    }
}