using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification;

namespace GeekMDSuite.WebAPI.DataAccess.Services.Classification
{
    public class QuantitativeLabClassificationService : IQuantitativeLabsClassificationService
    {
        public QuantitativeLabResult Classify(QuantitativeLabClassificationParameters obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return new QuantitativeLabClassification(obj).Classification;
        }
    }
}