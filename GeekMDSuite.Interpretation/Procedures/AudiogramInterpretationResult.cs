using GeekMDSuite.Common;
using GeekMDSuite.Common.Services;

namespace GeekMDSuite.Interpretation.Procedures
{
    public class AudiogramInterpretationResult
    {
        public HearingLossClassification Classification { get; set; }
        public Laterality Laterality { get; set; }
        public Laterality WorstSide { get; set; }
    }
}