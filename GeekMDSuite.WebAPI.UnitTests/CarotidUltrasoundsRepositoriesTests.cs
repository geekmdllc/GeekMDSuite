using System.Linq;
using GeekMDSuite.Procedures;
using GeekMDSuite.WebAPI.Models;
using GeekMDSuite.WebAPI.Repositories;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests
{
    public class CarotidUltrasoundsRepositoriesTests
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork(FakeGeekMdSuiteContextBuilder.Context);

        [Fact]
        public void Update_GivenNewIntimaMediaThickness_PersistsChangesInCorrectField()
        {
            var cueBefore = _unitOfWork.CarotidUltrasounds.All().First();
            var beforeImtLeft = cueBefore.Left.IntimaMediaMeasurementMillimeters;
            var beforeImtRight = cueBefore.Right.IntimaMediaMeasurementMillimeters;

            var newCu = new CarotidUltrasoundEntity()
            {
                Id = cueBefore.Id,
                Left = (CarotidUltrasoundResultBuilder.Initialize()
                    .SetIntimaMediaThickeness(0.802)
                    .Build()),
                Right = (CarotidUltrasoundResultBuilder.Initialize()
                    .SetIntimaMediaThickeness(0.801)
                    .Build())
            };
            
            _unitOfWork.CarotidUltrasounds.Update(newCu);
            _unitOfWork.Complete();

            var cueAfter = _unitOfWork.CarotidUltrasounds.FindById(cueBefore.Id);
            
            Assert.NotEqual(beforeImtRight, cueAfter.Right.IntimaMediaMeasurementMillimeters);
            Assert.NotEqual(beforeImtLeft, cueAfter.Left.IntimaMediaMeasurementMillimeters);
            Assert.Equal(0.801, cueAfter.Right.IntimaMediaMeasurementMillimeters);
            Assert.Equal(0.802, cueAfter.Left.IntimaMediaMeasurementMillimeters);
        }
    }
}