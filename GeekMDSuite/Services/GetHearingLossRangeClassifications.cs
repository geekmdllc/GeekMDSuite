using GeekMDSuite.Tools;

namespace GeekMDSuite.Services
{
    public static class GetHearingLossRangeClassifications
    {
        public static Interval<int> GetRange(
            HearingLossClassification classification)
        {
            if (classification == HearingLossClassification.None)
                return new Interval<int>(0, 20);
            if (classification == HearingLossClassification.Mild)
                return new Interval<int>(21, 40);
            if (classification == HearingLossClassification.Moderate)
                return new Interval<int>(41, 60);
            return classification == HearingLossClassification.Severe
                ? new Interval<int>(61, 80)
                : new Interval<int>(81, 200);
        }
    }
}