using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.Core.Tools.Generic;

namespace GeekMDSuite.Analytics.Repositories
{
    internal static class HearingLossClassificationRepository
    {
        public static Interval<int> GetRange(
            HearingLoss classification)
        {
            if (classification == HearingLoss.None)
                return new Interval<int>(0, 20);
            if (classification == HearingLoss.Mild)
                return new Interval<int>(21, 40);
            if (classification == HearingLoss.Moderate)
                return new Interval<int>(41, 60);
            return classification == HearingLoss.Severe
                ? new Interval<int>(61, 80)
                : new Interval<int>(81, 200);
        }
    }
}