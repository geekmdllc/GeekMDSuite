using GeekMDSuite.Core;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class PushupsClassification : MuscularStrengthClassification
    {
        public PushupsClassification(Pushups test, Patient patient) : base(test, patient)
        {
        }
    }
}