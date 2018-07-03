using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class PushupsClassificationParameters : MuscularStrengthClassificationParameters
    {
        public PushupsClassificationParameters(Pushups test, Patient patient)
        {
            Test = test;
            Patient = patient;
        }
    }
}