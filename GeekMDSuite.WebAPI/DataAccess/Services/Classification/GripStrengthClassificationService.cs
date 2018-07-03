using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification;

namespace GeekMDSuite.WebAPI.DataAccess.Services.Classification
{
    public class GripStrengthClassificationService : IGripStrengthClassificationService
    {
        public GripStrengthClassification Classify(GripStrengthClassificationParameters obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return new GripStrengthClassification(obj);
        }
    }
}