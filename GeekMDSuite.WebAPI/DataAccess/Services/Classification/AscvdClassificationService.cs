using System;
using GeekMDSuite.Analytics.Classification.CompositeScores;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification.CompositeScores;

namespace GeekMDSuite.WebAPI.DataAccess.Services.Classification
{
    public class AscvdClassificationService : IAscvdClassificationService
    {
        public AscvdClassificationResult Classify(AscvdParameters obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return new  AscvdClassification(obj).Classification;
        }
    }
}