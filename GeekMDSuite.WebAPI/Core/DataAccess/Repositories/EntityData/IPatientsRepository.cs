using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData
{
    public interface IPatientsRepository : IRepository<PatientEntity>
    {
        Task<IEnumerable<PatientEntity>> FindByName(string query);
        Task<IEnumerable<PatientEntity>>  FindByMedicalRecordNumber(string query);
        Task<IEnumerable<PatientEntity>>  FindByDateOfBirth(DateTime dateOfBirth);
        Task<PatientEntity> FindByGuid(Guid guid);
    }
}