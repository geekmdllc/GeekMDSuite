using System;
using System.Linq;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification;

namespace GeekMDSuite.WebAPI.DataAccess.Services.Classification
{
    public class BodyCompositionClassificationService : IBodyCompositionClassificationService
    {
        public BodyCompositionClassificationResult Classify(BodyComposition obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            throw new NotImplementedException();
        }
    }
}