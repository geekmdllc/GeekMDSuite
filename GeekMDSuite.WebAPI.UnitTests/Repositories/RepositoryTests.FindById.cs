using System.Linq;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Repositories
{
    public partial class RepositoryTests
    {
        [Fact]
        public async Task FindById_GivenEmptyContext_ThrowsRepositoryElementNotFoundException()
        {
            var repository = _unitOfWorkEmpty.VisitData<AudiogramEntity>();

            await Assert.ThrowsAsync<RepositoryEntityNotFoundException>(() => repository.FindById(1));
        }

        [Fact]
        public async Task FindById_GivenIndexWithoutElement_ThrowsRespositoryNotFoundException()
        {
            var audiograms = _unitOfWorkSeeded.VisitData<AudiogramEntity>();

            await Assert.ThrowsAsync<RepositoryEntityNotFoundException>(() => audiograms.FindById(int.MaxValue));
        }

        [Fact]
        public async Task FindById_ReturnsCorrectEntity()
        {
            var firstEntity = (await _unitOfWorkSeeded.EntityData<AudiogramEntity>().All()).First();
            var foundEntity = await _unitOfWorkSeeded.EntityData<AudiogramEntity>().FindById(firstEntity.Id);
            Assert.Equal(firstEntity, foundEntity);
        }
    }
}