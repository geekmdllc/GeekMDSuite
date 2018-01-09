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
        public async Task All_GivenEmptyContext_ThrowsRepositoryElementNotFoundException()
        {
            await Assert.ThrowsAsync<RepositoryElementNotFoundException>(() =>
                _unitOfWorkEmpty.VisitData<AudiogramEntity>().All());
        }

        [Fact]
        public async Task All_GivenSeededContext_ReturnsNonEmptyList()
        {
            var found = await _unitOfWorkSeeded.VisitData<AudiogramEntity>().All();

            Assert.True(found.Any());
        }
    }
}