using System;

namespace GeekMDSuite.Analytics.Classification
{
    public class SitupsClassification : MuscularStrengthClassification
    {
        public SitupsClassification(MuscularStrengthClassificationParameters parameters) : base(parameters.Test,
            parameters.Patient)
        {
            if (parameters.Test == null) throw new ArgumentNullException(nameof(parameters.Test));
            if (parameters.Patient == null) throw new ArgumentNullException(nameof(parameters.Patient));
        }
    }
}