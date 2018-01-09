using System.Linq;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.DataAccess;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Repositories
{
    public partial class RepositoryTests
    {
        [Fact]
        public async Task Delete_GivenId_Succeeds()
        {
            var uow = new UnitOfWork(FakeGeekMdSuiteContextBuilder.Context);
            var audiogram = (await uow.Audiograms
                .FindByPatientGuid(FakeGeekMdSuiteContextBuilder.BruceWaynesGuid))
                .First();
                

            await uow.Audiograms.Delete(audiogram.Id);
            await uow.Complete();

            await Assert.ThrowsAsync<RepositoryElementNotFoundException>(() =>
                uow.Audiograms.FindById(audiogram.Id));
        }

        [Fact]
        public async Task Delete_GivenIndexOutOfRange_ThrowsRepositoryElementNotFoundException()
        {
            await Assert.ThrowsAsync<RepositoryElementNotFoundException>(() =>
                _unitOfWorkSeeded.VisitData<AudiogramEntity>().Delete(int.MaxValue));
        }
    }
}