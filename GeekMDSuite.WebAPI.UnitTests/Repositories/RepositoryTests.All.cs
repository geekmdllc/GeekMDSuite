using System.Linq;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Repositories
{
    public partial class RepositoryTests
    {
        [Fact]
        public void All_GivenSeededContext_ReturnsNonEmptyList()
        {
            var found = _unitOfWorkSeeded.VisitData<AudiogramEntity>().All();

            Assert.True(found.Any());
        }

        [Fact]
        public void All_GivenEmptyContext_ThrowsRepositoryElementNotFoundException()
        {
            Assert.Throws<RepositoryElementNotFoundException>(() =>
                _unitOfWorkEmpty.VisitData<AudiogramEntity>().All());
        }
    }
}