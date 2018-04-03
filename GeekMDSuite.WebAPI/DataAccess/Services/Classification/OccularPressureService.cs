using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification;

namespace GeekMDSuite.WebAPI.DataAccess.Services.Classification
{
    public class OccularPressureService : IOccularPressureService
    {
        public OccularPressureClassificationResult Classify(OccularPressure obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return new OccularPressureClassification(obj).Classification;
        }
    }
}