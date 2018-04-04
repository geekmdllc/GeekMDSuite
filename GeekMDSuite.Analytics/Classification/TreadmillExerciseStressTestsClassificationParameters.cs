using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class TreadmillExerciseStressTestsClassificationParameters
    {
        public TreadmillExerciseStressTestsClassificationParameters(
            TreadmillExerciseStressTest treadmillExerciseStressTest, Patient patient)
        {
            TreadmillExerciseStressTest = treadmillExerciseStressTest;
            Patient = patient;
        }

        public TreadmillExerciseStressTest TreadmillExerciseStressTest { get; }
        public Patient Patient { get; }
    }
}