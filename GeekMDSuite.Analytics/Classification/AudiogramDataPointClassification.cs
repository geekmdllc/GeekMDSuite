using System;
using GeekMDSuite.Analytics.Repositories;
using GeekMDSuite.Core.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class AudiogramDataPointClassification : IClassifiable<HearingLoss>
    {
        public AudiogramDataPointClassification(IAudiogramDatapoint datapoint)
        {
            _datapoint = datapoint ?? throw new ArgumentNullException(nameof(datapoint));
        }
        public HearingLoss Classification => Classify(_datapoint.Value);

        public static HearingLoss Classify(int value)
        {
            if (value < LowerLimits.Mild) return HearingLoss.None;
            if (value < LowerLimits.Moderate) return HearingLoss.Mild;
            if (value < LowerLimits.Severe) return HearingLoss.Moderate;
            return value < LowerLimits.Profound ? HearingLoss.Severe : HearingLoss.Profound;
        }

        public static class LowerLimits
        {
            public static readonly int Normal = HearingLossClassificationRepository.GetRange(HearingLoss.None).Lower;
            public static readonly int Mild = HearingLossClassificationRepository.GetRange(HearingLoss.Mild).Lower;
            public static readonly int Moderate = HearingLossClassificationRepository.GetRange(HearingLoss.Moderate).Lower;
            public static readonly int Severe = HearingLossClassificationRepository.GetRange(HearingLoss.Severe).Lower;
            public static readonly int Profound = HearingLossClassificationRepository.GetRange(HearingLoss.Profound).Lower;
            public static int UnderWeight { get; set; }
        }
        
        private readonly IAudiogramDatapoint _datapoint;
    }
}