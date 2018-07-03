using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification;

namespace GeekMDSuite.WebAPI.DataAccess.Services.Classification
{
    public class FitTreadmillScoreClassificationService : IFitTreadmillScoreClassificationService
    {
        public FitTreadmillScoreMortality Classify(TreadmillExerciseStressTestClassificationParameters obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return new FitTreadmillScoreClassification(obj).Classification;
        }
    }
}