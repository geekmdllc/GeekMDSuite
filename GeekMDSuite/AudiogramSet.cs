using System.Collections.Generic;
using System.Linq;

namespace GeekMDSuite
{
    public class AudiogramSet
    {
        public AudiogramDatapoint F250 { get; set; }
        public AudiogramDatapoint F500 { get; set; }
        public AudiogramDatapoint F1000 { get; set; }
        public AudiogramDatapoint F2000 { get; set; }
        public AudiogramDatapoint F3000 { get; set; }
        public AudiogramDatapoint F4000 { get; set; }
        public AudiogramDatapoint F6000 { get; set; }
        public AudiogramDatapoint F8000 { get; set; }
        
        public int HighestDatapoint
        {
            get
            {
                var list = new List<int>
                {
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