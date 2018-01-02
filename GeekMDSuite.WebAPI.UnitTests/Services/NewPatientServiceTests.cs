using System;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.DataAccess.Services;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Services
{
    public class NewPatientServiceTests
    {
        [Fact]
        public void GenerateUsing_WithoutLoadingContext_ThrowsContextNotLoadedException()
        {
            Assert.Throws<UnitOfWorkNotLoadedException>(() => _service.GenerateUsing(new PatientEntity()));
        }

        [Fact]
        public void GenerateUsing_WhenProperlyLoadedAndGivenNullPatient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _service.WithUnitOfWork(_unitOfWork).GenerateUsing(null));
        }

        [Fact]
        public void GenerateUsing_WhenProperlyLoadedAndGivenNewPatient_Succeeds()
        {
            var newPatient = _service.WithUnitOfWork(_unitOfWork).GenerateUsing(new PatientEntity());
            Assert.True(newPatient != null && newPatient.Guid != Guid.Empty);
        }
        
        private readonly INewPatientService _service = new NewPatientService();
        private readonly IUnitOfWork _unitOfWork = new FakeUnitOfWorkSeeded();
    }
}