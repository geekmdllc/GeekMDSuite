using System.Collections.Generic;
using GeekMDSuite.WebAPI.Models;

namespace GeekMDSuite.WebAPI.Repositories
{
    public interface IPatientRepository : IRepository<PatientEntity>
    {
        IEnumerable<PatientEntity> FindByName(string query);
        IEnumerable<PatientEntity> FindByMedicalRecordNumber(string query);
    }
}