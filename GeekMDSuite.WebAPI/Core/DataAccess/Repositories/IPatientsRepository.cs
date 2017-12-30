using System.Collections.Generic;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.Repositories
{
    public interface IPatientsRepository : IRepository<PatientEntity>
    {
        IEnumerable<PatientEntity> FindByName(string query);
        IEnumerable<PatientEntity> FindByMedicalRecordNumber(string query);
    }
}