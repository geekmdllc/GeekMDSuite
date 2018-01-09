using System;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.DataAccess.Services;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Services
{
    public class NewPatientServiceTests
    {
        private readonly INewPatientService _service = new NewPatientService();
        private readonly IUnitOfWork _unitOfWork = new FakeUnitOfWorkSeeded();

        [Fact]
        public void GenerateUsing_WhenProperlyLoadedAndGivenNewPatient_Succeeds()
        {
            var newPatient = _service.WithUnitOfWork(_unitOfWork).GenerateUsing(
                new Patient
                {
                    Name = Name.Build("Joe", "Schmoe"),
                    MedicalRecordNumber = Guid.NewGuid().ToString(),
                    DateOfBirth = new DateTime(1985, 4, 19)
                });
            Assert.True(newPatient != null && newPatient.Guid != Guid.Empty);
        }

        [Fact]
        public void GenerateUsing_WhenProperlyLoadedAndGivenNullPatient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _service.WithUnitOfWork(_unitOfWork).GenerateUsing(null));
        }

        [Fact]
        public void GenerateUsing_WithoutLoadingContext_ThrowsContextNotLoadedException()
        {
            Assert.Throws<UnitOfWorkNotLoadedException>(() => _service.GenerateUsing(new Patient()));
        }
    }
}