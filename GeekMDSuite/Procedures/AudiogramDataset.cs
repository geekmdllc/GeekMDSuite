using System.Collections.Generic;
using System.Linq;

namespace GeekMDSuite.Procedures
{
    public class AudiogramDataset
    {

        internal AudiogramDataset(
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
        
        public HearingLoss Classification => AudiogramDatapoint.Classify(HighestDatapoint);
        
        public AudiogramDatapoint F125 { get; }
        public AudiogramDatapoint F250 { get; }
        public AudiogramDatapoint F500 { get; }
        public AudiogramDatapoint F1000 { get; }
        public AudiogramDatapoint F2000 { get; }
        public AudiogramDatapoint F3000 { get; }
        public AudiogramDatapoint F4000 { get; }
        public AudiogramDatapoint F6000 { get; }
        public AudiogramDatapoint F8000 { get; }
        
        public int HighestDatapoint
        {
            get
            {
                var list = new List<int>
                {
                    F125?.Value ?? 0,
                    F250?.Value ?? 0,
                    F500?.Value ?? 0,
                    F1000?.Value ?? 0,
                    F2000?.Value ?? 0,
                    F3000?.Value ?? 0,
                    F4000?.Value ?? 0,
                    F6000?.Value ?? 0,
                    F8000?.Value ?? 0
                };
                return list.Max();
            }
        }
    }
}