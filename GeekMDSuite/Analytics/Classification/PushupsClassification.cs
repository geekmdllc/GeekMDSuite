using GeekMDSuite.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class PushupsClassification : MuscularStrengthClassification
    {
        private readonly IMuscularStrengthTest _test;
        private readonly IPatient _patient;

        public PushupsClassification(IMuscularStrengthTest test, IPatient patient) : base(test, patient)
        {
            _test = test;
            _patient = patient;
        }
    }
}