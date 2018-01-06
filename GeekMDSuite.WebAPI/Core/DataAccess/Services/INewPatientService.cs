using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Services
{
    public interface INewPatientService : INewKeyEntityService<PatientEntity, Patient>
    {
    }
}