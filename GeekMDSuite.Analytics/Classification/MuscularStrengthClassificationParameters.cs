using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public abstract class MuscularStrengthClassificationParameters
    {
        protected MuscularStrengthClassificationParameters()
        {
            
        }
        public MuscularStrengthClassificationParameters(MuscularStrengthTest test, Patient patient)
        {
            Test = test;
            Patient = patient;
        }

        public MuscularStrengthTest Test { get; set; }
        public Patient Patient { get; set; }
    }
}