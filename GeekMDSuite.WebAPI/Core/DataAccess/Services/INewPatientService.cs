using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using GeekMDSuite.WebAPI.Presentation.ResourceStubModels;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Services
{
    public interface INewPatientService : INewKeyEntityService<PatientEntity, PatientEntity>
    {
    }
}