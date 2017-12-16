using GeekMDSuite.Procedures;

namespace GeekMDSuite.Services.Interpretation
{
    public class SitAndReachInterpretation : MuscularStrengthInterpretation
    {
        public SitAndReachInterpretation(IMuscularStrengthTest test, IPatient patient) : base(test, patient)
        {
        }
    }
}