using GeekMDSuite.Procedures;

namespace GeekMDSuite.Services.Interpretation
{
    public class PushupsInterpretation : MuscularStrengthInterpretation
    {
        private readonly IMuscularStrengthTest _test;
        private readonly IPatient _patient;

        public PushupsInterpretation(IMuscularStrengthTest test, IPatient patient) : base(test, patient)
        {
            _test = test;
            _patient = patient;
        }
    }
}