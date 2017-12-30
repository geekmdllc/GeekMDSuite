using System.Collections.Generic;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using GeekMDSuite.WebAPI.Repositories;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Repositories
{
    public interface IPatientsRepository : IRepository<PatientEntity>
    {
        IEnumerable<PatientEntity> FindByName(string query);
        IEnumerable<PatientEntity> FindByMedicalRecordNumber(string query);
    }
}