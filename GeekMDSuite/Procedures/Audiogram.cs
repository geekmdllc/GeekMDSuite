namespace GeekMDSuite.Procedures
{
    public class Audiogram
    {
        private Audiogram (AudiogramDataset left, AudiogramDataset right)
        {
            Left = left;
            Right = right;
        }

        public AudiogramDataset Right { get; }
        public AudiogramDataset Left { get; }

        public static Audiogram Build(AudiogramDataset left, AudiogramDataset right) => new Audiogram(left, right);

        public override string ToString()
        {
            return $"Left: {Left}\nRight:{Right}";
        }
    }
}