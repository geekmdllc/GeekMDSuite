using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification;

namespace GeekMDSuite.WebAPI.DataAccess.Services.Classification
{
    public class CentralBloodPressureClassificationService : ICentralBloodPressureClassificationService
    {
        public CentralBloodPressureClassification Classify(CentralBloodPressureParameters obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return new CentralBloodPressureClassification(obj);
        }
    }
}