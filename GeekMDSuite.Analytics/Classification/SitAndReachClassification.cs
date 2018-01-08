using System;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class SitAndReachClassification : MuscularStrengthClassification
    {
        public SitAndReachClassification(MuscularStrengthClassificationParameters parameters) : base(parameters.Test, parameters.Patient)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            if (parameters.Test == null) throw new ArgumentNullException(nameof(parameters.Test));
            if (parameters.Patient == null) throw new ArgumentNullException(nameof(parameters.Patient));
        }
    }
}