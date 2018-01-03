using System;
using GeekMDSuite.Core;
using GeekMDSuite.Core.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class SitupsClassification : MuscularStrengthClassification
    {
        public SitupsClassification(IMuscularStrengthTest test, Patient patient) : base(test, patient)
        {
            if (test == null) throw new ArgumentNullException(nameof(test));
            if (patient == null) throw new ArgumentNullException(nameof(patient));
        }
    }
}