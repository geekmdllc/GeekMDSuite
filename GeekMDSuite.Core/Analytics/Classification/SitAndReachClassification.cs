using System;
using GeekMDSuite.Core.Procedures;

namespace GeekMDSuite.Core.Analytics.Classification
{
    public class SitAndReachClassification : MuscularStrengthClassification
    {
        public SitAndReachClassification(IMuscularStrengthTest test, IPatient patient) : base(test, patient)
        {
            if (test == null) throw new ArgumentNullException(nameof(test));
            if (patient == null) throw new ArgumentNullException(nameof(patient));
        }
    }
}