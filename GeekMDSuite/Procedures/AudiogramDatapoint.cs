using GeekMDSuite.Tools.Generic;

namespace GeekMDSuite.Procedures
{
    public class AudiogramDatapoint
    {
        public AudiogramDatapoint(int value)
        {
            Value = value;
        }
        
        public int Value { get; }
        public HearingLoss Classification => Classify(Value);

        public static HearingLoss Classify(int value)
        {
            if (NormalRange.ContainsClosed(value))
                return HearingLoss.None;
            if (MildRange.ContainsLeftOpen(value))
                return HearingLoss.Mild;
            if (ModerateRange.ContainsLeftOpen(value))
                return HearingLoss.Moderate;
            return SevereRange.ContainsLeftOpen(value)
                ? HearingLoss.Severe
                : HearingLoss.Profound;
        }
        
        public static Interval<int> NormalRange => HearingLossClassification.GetRange(HearingLoss.None);
        public static Interval<int> MildRange => HearingLossClassification.GetRange(HearingLoss.Mild);
        public static Interval<int> ModerateRange => HearingLossClassification.GetRange(HearingLoss.Moderate);
        public static Interval<int> SevereRange => HearingLossClassification.GetRange(HearingLoss.Severe);
        public static Interval<int> ProfounRange => HearingLossClassification.GetRange(HearingLoss.Profound);
    }
}