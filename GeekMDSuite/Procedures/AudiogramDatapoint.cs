namespace GeekMDSuite.Procedures
{
    public class AudiogramDatapoint
    {
        public AudiogramDatapoint(int value)
        {
            Value = value;
        }
        
        public int Value { get; }

        public override string ToString() => $"{Value}dB";
    }
}