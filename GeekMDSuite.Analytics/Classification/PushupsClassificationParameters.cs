using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class PushupsClassificationParameters
    {
        public PushupsClassificationParameters(Pushups test, Patient patient)
        {
            Test = test;
            Patient = patient;
        }

        public Pushups Test { get; private set; }
        public Patient Patient { get; private set; }
    }
}