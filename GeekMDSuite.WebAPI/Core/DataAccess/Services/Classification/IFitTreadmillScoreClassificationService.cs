using GeekMDSuite.Analytics.Classification;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification
{
    public interface IFitTreadmillScoreClassificationService : IClassificationService<
        TreadmillExerciseStressTestClassificationParameters, FitTreadmillScoreMortality>
    {
        
    }
}