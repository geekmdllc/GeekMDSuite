using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class SitupsClassificationParameters : MuscularStrengthClassificationParameters
    {
        public SitupsClassificationParameters(Situps test, Patient patient)
        {
            Test = test;
            Patient = patient;
        }
    }
}