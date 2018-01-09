namespace GeekMDSuite.Core.Models.Procedures
{
    public class AudiogramDatapoint
    {
        internal AudiogramDatapoint(int value)
        {
            Value = value;
        }

        public AudiogramDatapoint()
        {
        }

        public int Value { get; set; }

        public static AudiogramDatapoint Build(int value)
        {
            return new AudiogramDatapoint(value);
        }

        public override string ToString()
        {
            return $"{Value}dB";
        }
    }
}