using GeekMDSuite.Core;
using GeekMDSuite.Core.Helpers;

namespace GeekMDSuite.Analytics.Classification
{
    public class BloodPressureClassificationResult
    {
        public BloodPressureStage Stage { get; set; }
        public string Description => Stage.ToString().SplitAtCapitalization();
        public BloodPressure Pressure { get; set; }

        public BloodPressureClassificationResult()
        {
            Pressure = new BloodPressure();
        }

        public BloodPressureClassificationResult Build(BloodPressure bloodPressure, BloodPressureStage stage)
        {
            Stage = stage;
            Pressure = Pressure;
            return this;
        }

        public override string ToString() => Description;
    }
}