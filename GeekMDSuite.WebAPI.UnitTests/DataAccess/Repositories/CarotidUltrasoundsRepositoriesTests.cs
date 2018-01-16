using System.Linq;
using System.Threading.Tasks;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.DataAccess.Repositories
{
    public class CarotidUltrasoundsRepositoriesTests
    {
        private readonly IUnitOfWork _unitOfWork = new FakeUnitOfWorkSeeded();

        [Fact]
        public async Task Update_GivenNewIntimaMediaThickness_PersistsChangesInCorrectField()
        {
            var cueBefore = (await _unitOfWork.CarotidUltrasounds.All()).First();
            var beforeImtLeft = cueBefore.Left.IntimaMediaMeasurementMillimeters;
            var beforeImtRight = cueBefore.Right.IntimaMediaMeasurementMillimeters;

            var newCu = new CarotidUltrasoundEntity
            {
                Id = cueBefore.Id,
                Left = CarotidUltrasoundResultBuilder.Initialize()
                    .SetIntimaMediaThickeness(0.802)
                    .Build(),
                Right = CarotidUltrasoundResultBuilder.Initialize()
                    .SetIntimaMediaThickeness(0.801)
                    .Build()
            };

            await _unitOfWork.CarotidUltrasounds.Update(newCu);
            await _unitOfWork.Complete();

            var cueAfter = await _unitOfWork.CarotidUltrasounds.FindById(cueBefore.Id);

            Assert.NotEqual(beforeImtRight, cueAfter.Right.IntimaMediaMeasurementMillimeters);
            Assert.NotEqual(beforeImtLeft, cueAfter.Left.IntimaMediaMeasurementMillimeters);
            Assert.Equal(0.801, cueAfter.Right.IntimaMediaMeasurementMillimeters);
            Assert.Equal(0.802, cueAfter.Left.IntimaMediaMeasurementMillimeters);
        }
    }
}