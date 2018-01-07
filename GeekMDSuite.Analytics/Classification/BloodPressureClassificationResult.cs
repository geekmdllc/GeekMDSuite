using GeekMDSuite.Core.Models;
using GeekMDSuite.Utilities.Extensions;

namespace GeekMDSuite.Analytics.Classification
{
    public class BloodPressureClassificationResult
    {
        public BloodPressureClassificationResult()
        {
            Pressure = new BloodPressure();
        }

        public BloodPressureStage Stage { get; set; }
        public string Description => Stage.ToString().SplitAtCapitalization();
        public BloodPressure Pressure { get; set; }

        public BloodPressureClassificationResult Build(BloodPressure bloodPressure, BloodPressureStage stage)
        {
            Stage = stage;
            Pressure = Pressure;
            return this;
        }

        public override string ToString()
        {
            return Description;
        }
    }
}