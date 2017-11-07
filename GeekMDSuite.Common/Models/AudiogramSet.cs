using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.Common.Models;

namespace GeekMDSuite.Common.Models
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
                    F250.Value,
                    F500.Value,
                    F1000.Value,
                    F2000.Value,
                    F3000.Value,
                    F4000.Value,
                    F6000.Value,
                    F8000.Value
                };
                return list.Max();
            }
        }
    }
}