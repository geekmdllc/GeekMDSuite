using System;
using System.Threading.Tasks;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.DataAccess.Services;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.DataAccess.Services
{
    public class NewPatientServiceTests
    {
        private readonly INewPatientService _service = new NewPatientService();
        private readonly IUnitOfWork _unitOfWork = new FakeUnitOfWorkSeeded();

        [Fact]
        public async Task GenerateUsing_WhenProperlyLoadedAndGivenNewPatient_Succeeds()
        {
            var newPatient = await _service.WithUnitOfWork(_unitOfWork).UsingTemplatePatientEntity(
                new PatientEntity
                {
                    Name = Name.Build("Joe", "Schmoe"),
                    MedicalRecordNumber = Guid.NewGuid().ToString(),
                    DateOfBirth = new DateTime(1985, 4, 19)
                });
            Assert.True(newPatient != null && newPatient.Guid != Guid.Empty);
        }

        [Fact]
        public async Task GenerateUsing_WhenProperlyLoadedAndGivenNullPatient_ThrowsArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                _service.WithUnitOfWork(_unitOfWork).UsingTemplatePatientEntity(null));
        }

        [Fact]
        public async Task GenerateUsing_WithoutLoadingContext_ThrowsContextNotLoadedException()
        {
            await Assert.ThrowsAsync<UnitOfWorkNotLoadedException>(() =>
                _service.UsingTemplatePatientEntity(new PatientEntity()));
        }
    }
}