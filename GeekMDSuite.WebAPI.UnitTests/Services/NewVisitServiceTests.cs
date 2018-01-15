using System;
using System.Threading.Tasks;
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
        public async Task GenerateUsing_WhenProperlyLoadedAndGivenNewPatient_Succeeds()
        {
            var newVisit = await _service.WithUnitOfWork(_unitOfWork).UsingTemplatePatientEntity(
                new VisitEntity
                {
                    PatientGuid = Guid.NewGuid()
                });

            Assert.True(newVisit != null && newVisit.Guid != Guid.Empty);
        }

        [Fact]
        public async Task GenerateUsing_WhenProperlyLoadedAndGivenNullPatient_ThrowsArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                _service.WithUnitOfWork(_unitOfWork).UsingTemplatePatientEntity(null));
        }

        [Fact]
        public async Task GenerateUsing_WhenProperlyLoadedAndGivenPatientWithEmptyGuid_ThrowsFormatException()
        {
            await Assert.ThrowsAsync<FormatException>(() => _service
                .WithUnitOfWork(_unitOfWork)
                .UsingTemplatePatientEntity(new VisitEntity
                {
                    PatientGuid = Guid.Empty
                }));
        }

        [Fact]
        public async Task GenerateUsing_WithoutLoadingContext_ThrowsContextNotLoadedException()
        {
            await Assert.ThrowsAsync<UnitOfWorkNotLoadedException>(() =>
                _service.UsingTemplatePatientEntity(new VisitEntity()));
        }
    }
}