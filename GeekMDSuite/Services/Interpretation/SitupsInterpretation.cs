using GeekMDSuite.Procedures;

namespace GeekMDSuite.Services.Interpretation
{
    public class SitupsInterpretation : MuscularStrengthInterpretation
    {
        public SitupsInterpretation(IMuscularStrengthTest test, IPatient patient) : base(test, patient)
        {
        }
    }
}