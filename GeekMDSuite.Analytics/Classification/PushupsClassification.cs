using GeekMDSuite.Core;
using GeekMDSuite.Core.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class PushupsClassification : MuscularStrengthClassification
    {
        public PushupsClassification(IMuscularStrengthTest test, Patient patient) : base(test, patient)
        {
        }
    }
}