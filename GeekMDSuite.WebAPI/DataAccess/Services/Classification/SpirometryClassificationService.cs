using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification;

namespace GeekMDSuite.WebAPI.DataAccess.Services.Classification
{
    public class SpirometryClassificationService : ISpirometryClassificationService
    {
        public SpirometryClassificationResult Classify(SpirometryClassificationParameters obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return new SpirometryClassification(obj).Classification;
        }
    }
}