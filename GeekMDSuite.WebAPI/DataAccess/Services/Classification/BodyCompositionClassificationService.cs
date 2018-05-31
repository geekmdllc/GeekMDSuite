using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification;

namespace GeekMDSuite.WebAPI.DataAccess.Services.Classification
{
    public class BodyCompositionClassificationService : IBodyCompositionClassificationService
    {
        public BodyCompositionClassificationResult Classify(BodyCompositionClassificationParameters obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return new BodyCompositionClassification(obj).Classification;
        }
    }
}