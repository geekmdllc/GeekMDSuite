using System;

namespace GeekMDSuite.Core.Procedures
{
    public class Audiogram : IAudiogram
    {
        private Audiogram (AudiogramDataset left, AudiogramDataset right)
        {
            Left = left ?? throw new ArgumentNullException(nameof(left));
            Right = right ?? throw new ArgumentNullException(nameof(right));
        }

        public AudiogramDataset Right { get; set; }
        public AudiogramDataset Left { get; set; }

        public static Audiogram Build(AudiogramDataset left, AudiogramDataset right) => new Audiogram(left, right);

        public override string ToString()
        {
            return $"Left: {Left}\nRight:{Right}";
        }

        protected Audiogram()
        {
            Right = new AudiogramDataset();
            Left = new AudiogramDataset();
        }
    }
}