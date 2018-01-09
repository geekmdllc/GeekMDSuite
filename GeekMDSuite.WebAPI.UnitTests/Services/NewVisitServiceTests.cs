using System;
using System.IO;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.DataAccess.Services;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Services
{
    public class NewVisitServiceTests
    {
        private readonly INewVisitService _service = new NewVisitService();
        private readonly IUnitOfWork _unitOfWork = new FakeUnitOfWorkSeeded();

        [Fact]
        public void GenerateUsing_WhenProperlyLoadedAndGivenNewPatient_Succeeds()
        {
            var newVisit = _service.WithUnitOfWork(_unitOfWork).GenerateUsing(
                new VisitEntity
                {
                    PatientGuid = Guid.NewGuid()
                });

            Assert.True(newVisit != null && newVisit.VisitId != Guid.Empty);
        }

        [Fact]
        public void GenerateUsing_WhenProperlyLoadedAndGivenNullPatient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _service.WithUnitOfWork(_unitOfWork).GenerateUsing(null));
        }

        [Fact]
        public void GenerateUsing_WhenProperlyLoadedAndGivenPatientWithEmptyGuid_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => _service
                .WithUnitOfWork(_unitOfWork)
                .GenerateUsing(new VisitEntity
                {
                    PatientGuid = Guid.Empty
                }));
        }

        [Fact]
        public void GenerateUsing_WithoutLoadingContext_ThrowsContextNotLoadedException()
        {
            Assert.Throws<UnitOfWorkNotLoadedException>(() => _service.GenerateUsing(new VisitEntity()));
        }
    }
}