using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class Vo2MaxClassificationParameters
    {
        public Vo2MaxClassificationParameters(TreadmillExerciseStressTest treadmillExerciseTest, Patient patient)
        {
            TreadmillExerciseTest = treadmillExerciseTest;
            Patient = patient;
        }

        public TreadmillExerciseStressTest TreadmillExerciseTest { get; }
        public Patient Patient { get; }
    }
}