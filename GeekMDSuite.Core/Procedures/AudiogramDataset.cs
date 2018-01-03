namespace GeekMDSuite.Core.Procedures
{
    public class AudiogramDataset 
    {
        internal static AudiogramDataset Build(
            AudiogramDatapoint f125,
            AudiogramDatapoint f250,
            AudiogramDatapoint f500,
            AudiogramDatapoint f1000,
            AudiogramDatapoint f2000,
            AudiogramDatapoint f3000,
            AudiogramDatapoint f4000,
            AudiogramDatapoint f6000,
            AudiogramDatapoint f8000)
        {
            return new AudiogramDataset(f125, f250, f500, f1000, f2000, f3000, f4000, f6000, f8000);
        }
        private AudiogramDataset(
            AudiogramDatapoint f125,
            AudiogramDatapoint f250,
            AudiogramDatapoint f500,
            AudiogramDatapoint f1000,
            AudiogramDatapoint f2000,
            AudiogramDatapoint f3000,
            AudiogramDatapoint f4000,
            AudiogramDatapoint f6000,
            AudiogramDatapoint f8000)
        {
            F125 = f125;
            F250 = f250;
            F500 = f500;
            F1000 = f1000;
            F2000 = f2000;
            F3000 = f3000;
            F4000 = f4000;
            F6000 = f6000;
            F8000 = f8000;
        }
        public AudiogramDatapoint F125 { get; set; }
        public AudiogramDatapoint F250 { get; set; }
        public AudiogramDatapoint F500 { get; set; }
        public AudiogramDatapoint F1000 { get; set; }
        public AudiogramDatapoint F2000 { get; set; }
        public AudiogramDatapoint F3000 { get; set; }
        public AudiogramDatapoint F4000 { get; set; }
        public AudiogramDatapoint F6000 { get; set; }
        public AudiogramDatapoint F8000 { get; set; }

        public override string ToString()
        {
            return $".125K {F125} .25K {F250} .5K {F500} 1K {F1000} 2K {F2000} 3K {F3000} 4K {F4000} 6K {F6000} 8K {F8000}";
        }

        protected internal AudiogramDataset()
        {
            F125 = new AudiogramDatapoint();
            F250 = new AudiogramDatapoint();
            F500 = new AudiogramDatapoint();
            F1000 = new AudiogramDatapoint();
            F2000 = new AudiogramDatapoint();
            F3000 = new AudiogramDatapoint();
            F4000 = new AudiogramDatapoint();
            F6000 = new AudiogramDatapoint();
            F8000 = new AudiogramDatapoint();
        }
    }
}