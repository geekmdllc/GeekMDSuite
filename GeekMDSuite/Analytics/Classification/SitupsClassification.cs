using System;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class SitupsClassification : MuscularStrengthClassification
    {
        public SitupsClassification(IMuscularStrengthTest test, IPatient patient) : base(test, patient)
        {
            if (test == null) throw new ArgumentNullException(nameof(test));
            if (patient == null) throw new ArgumentNullException(nameof(patient));
        }
    }
}