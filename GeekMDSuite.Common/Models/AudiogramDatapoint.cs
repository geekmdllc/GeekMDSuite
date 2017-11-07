using GeekMDSuite.Common.Services;

namespace GeekMDSuite.Common.Models
{
    public class AudiogramDatapoint
    {
        public int Value { get; set; }
        public HearingLossClassification Flag { get; set; }
    }
}