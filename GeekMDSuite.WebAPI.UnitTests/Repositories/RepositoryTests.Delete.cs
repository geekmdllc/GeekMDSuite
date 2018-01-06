using System.Linq;
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
        public void Delete_GivenId_Succeeds()
        {
            var uow = new UnitOfWork(FakeGeekMdSuiteContextBuilder.Context);
            var audiogram = uow.Audiograms
                .FindByPatientGuid(FakeGeekMdSuiteContextBuilder.BruceWaynesGuid)
                .First();

            uow.Audiograms.Delete(audiogram.Id);
            uow.Complete();

            Assert.Throws<RepositoryElementNotFoundException>(() =>
                uow.Audiograms.FindById(audiogram.Id));
        }

        [Fact]
        public void Delete_GivenIndexOutOfRange_ThrowsRepositoryElementNotFoundException()
        {
            Assert.Throws<RepositoryElementNotFoundException>(() =>
                _unitOfWorkSeeded.VisitData<AudiogramEntity>().Delete(int.MaxValue));
        }
    }
}