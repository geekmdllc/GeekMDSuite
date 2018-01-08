using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification;

namespace GeekMDSuite.WebAPI.DataAccess.Services.Classification
{
    public class BloodPressureClassificationService : IBloodPressureClassificationService
    {
        public BloodPressureClassificationResult Classify(BloodPressure obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return new BloodPressureClassification(obj).Classification;
        }
    }
}