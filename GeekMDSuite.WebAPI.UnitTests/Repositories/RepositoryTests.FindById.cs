using System.Linq;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Repositories
{
    public partial class RepositoryTests
    {
        [Fact]
        public void FindById_GivenEmptyContext_ThrowsRepositoryElementNotFoundException()
        {
            var repository = _unitOfWorkEmpty.VisitData<AudiogramEntity>();

            Assert.Throws<RepositoryElementNotFoundException>(() => repository.FindById(1));
        }

        [Fact]
        public void FindById_GivenIndexWithoutElement_ThrowsRespositoryNotFoundException()
        {
            var audiograms = _unitOfWorkSeeded.VisitData<AudiogramEntity>();

            Assert.Throws<RepositoryElementNotFoundException>(() => audiograms.FindById(int.MaxValue));
        }

        [Fact]
        public void FindById_ReturnsCorrectEntity()
        {
            var firstEntity = _unitOfWorkSeeded.EntityData<AudiogramEntity>().All().First();
            var foundEntity = _unitOfWorkSeeded.EntityData<AudiogramEntity>().FindById(firstEntity.Id);
            Assert.Equal(firstEntity, foundEntity);
        }
    }
}