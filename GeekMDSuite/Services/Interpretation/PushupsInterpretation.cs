using GeekMDSuite.Procedures;

namespace GeekMDSuite.Services.Interpretation
{
    public class PushupsInterpretation : MuscularStrengthInterpretation
    {
        public PushupsInterpretation(IMuscularStrengthTest test, IPatient patient) : base(test, patient)
        {
        }
    }
}