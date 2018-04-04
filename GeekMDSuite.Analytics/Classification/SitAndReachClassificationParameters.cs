using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class SitAndReachClassificationParameters : MuscularStrengthClassificationParameters
    {
        public SitAndReachClassificationParameters(SitAndReach test, Patient patient)
        {
            Test = test;
            Patient = patient;
        }
    }
}