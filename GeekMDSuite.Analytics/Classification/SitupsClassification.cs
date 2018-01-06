using System;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class SitupsClassification : MuscularStrengthClassification
    {
        public SitupsClassification(Situps test, Patient patient) : base(test, patient)
        {
            if (test == null) throw new ArgumentNullException(nameof(test));
            if (patient == null) throw new ArgumentNullException(nameof(patient));
        }
    }
}