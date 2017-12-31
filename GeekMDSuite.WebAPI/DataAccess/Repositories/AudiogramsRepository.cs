using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class AudiogramsRepository : RepositoryAssociatedWithVisit<AudiogramEntity>, IAudiogramsRepository
    {
        public AudiogramsRepository(GeekMdSuiteDbContext context) : base (context)
        {
        }
    }
}