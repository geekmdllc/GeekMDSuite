using System;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.Services.Interpretation
{
    public class SitAndReachInterpretation : MuscularStrengthInterpretation
    {
        public SitAndReachInterpretation(IMuscularStrengthTest test, IPatient patient) : base(test, patient)
        {
            if (test == null) throw new ArgumentNullException(nameof(test));
            if (patient == null) throw new ArgumentNullException(nameof(patient));
        }
    }
}