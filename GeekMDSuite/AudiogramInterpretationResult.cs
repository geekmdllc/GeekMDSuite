using GeekMDSuite.Services;

namespace GeekMDSuite
{
    public class AudiogramInterpretationResult
    {
        public HearingLossClassification Classification { get; set; }
        public Laterality Laterality { get; set; }
        public Laterality WorstSide { get; set; }
    }
}