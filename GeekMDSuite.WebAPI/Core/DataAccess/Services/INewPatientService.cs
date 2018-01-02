using GeekMDSuite.Core;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Services
{
    public interface INewPatientService
    {
        PatientEntity GenerateUsing(Patient patient);
    }
}