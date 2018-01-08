using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification;

namespace GeekMDSuite.WebAPI.DataAccess.Services.Classification
{
    public class BodyCompositionsExpandedClassificationService : IBodyCompositionExpandedClassificationService
    {
        public BodyCompositionClassificationResult Classify(BodyCompositionExpandedClassificationParameters obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return new BodyCompositionExpandedClassification(obj).Classification;
        }
    }
}