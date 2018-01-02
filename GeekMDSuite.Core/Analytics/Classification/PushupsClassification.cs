using GeekMDSuite.Core.Procedures;

namespace GeekMDSuite.Core.Analytics.Classification
{
    public class PushupsClassification : MuscularStrengthClassification
    {
        public PushupsClassification(IMuscularStrengthTest test, IPatient patient) : base(test, patient)
        {
        }
    }
}