using GeekMDSuite.Services;

namespace GeekMDSuite.Models
{
    public class AudiogramDatapoint
    {
        public int Value { get; set; }
        public HearingLossClassification Flag { get; set; }
    }
}