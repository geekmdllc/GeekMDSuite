using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification;

namespace GeekMDSuite.WebAPI.DataAccess.Services.Classification
{
    public class SitAndReachClassificationService : ISitAndReachClassificationService
    {
        public FitnessClassification Classify(SitAndReachClassificationParameters obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return new SitAndReachClassification(obj).Classification;
        }
    }
}