using System;
using System.Collections.Generic;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData
{
    public interface IPatientsRepository : IRepository<Patient>
    {
        IEnumerable<Patient> FindByName(string query);
        IEnumerable<Patient> FindByMedicalRecordNumber(string query);
        IEnumerable<Patient> FindByDateOfBirth(DateTime dateOfBirth);
        Patient FindByGuid(Guid guid);
    }
}