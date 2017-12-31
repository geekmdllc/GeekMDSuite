using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class TreadmillExerciseStressTestsRepository :
        RepositoryAssociatedWithVisit<TreadmillExerciseStressTestEntity>, ITreadmillExerciseStressTestsRepository
    {
        public TreadmillExerciseStressTestsRepository(GeekMdSuiteDbContext context) : base(context)
        {
        }
    }
}