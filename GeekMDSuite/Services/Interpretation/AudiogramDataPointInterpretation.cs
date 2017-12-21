using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Repositories;
using GeekMDSuite.Tools.Generic;

namespace GeekMDSuite.Services.Interpretation
{
    public class AudiogramDataPointInterpretation
    {
        private readonly AudiogramDatapoint _datapoint;

        public AudiogramDataPointInterpretation(AudiogramDatapoint datapoint)
        {
            _datapoint = datapoint;
        }
        public HearingLoss Classification => Classify(_datapoint.Value);

        public static HearingLoss Classify(int value)
        {
            if (NormalRange.ContainsClosed(value)) return HearingLoss.None;
            if (MildRange.ContainsLeftOpen(value)) return HearingLoss.Mild;
            if (ModerateRange.ContainsLeftOpen(value)) return HearingLoss.Moderate;
            return SevereRange.ContainsLeftOpen(value) ? HearingLoss.Severe : HearingLoss.Profound;
        }
        
        public static Interval<int> NormalRange => HearingLossClassificationRepository.GetRange(HearingLoss.None);
        public static Interval<int> MildRange => HearingLossClassificationRepository.GetRange(HearingLoss.Mild);
        public static Interval<int> ModerateRange => HearingLossClassificationRepository.GetRange(HearingLoss.Moderate);
        public static Interval<int> SevereRange => HearingLossClassificationRepository.GetRange(HearingLoss.Severe);
        public static Interval<int> ProfoundRange => HearingLossClassificationRepository.GetRange(HearingLoss.Profound);
    }
}