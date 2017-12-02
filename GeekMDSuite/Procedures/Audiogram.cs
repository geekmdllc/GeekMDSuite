namespace GeekMDSuite.Procedures
{
    public class Audiogram
    {
        public Audiogram (AudiogramDataset left, AudiogramDataset right)
        {
            Left = left;
            Right = right;
        }

        public AudiogramDataset Right { get; }
        public AudiogramDataset Left { get; }
    }
}