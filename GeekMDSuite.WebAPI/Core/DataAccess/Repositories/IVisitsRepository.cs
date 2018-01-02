using System;
using System.Collections.Generic;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Repositories
{
    public interface IVisitsRepository : IRepository<VisitEntity>
    {
        VisitEntity FindByPatientGuid(Guid patientGuid);
        IEnumerable<VisitEntity> FindByMedicalRecordNumber(string mrn);
        IEnumerable<VisitEntity> FindByName(string name);
        IEnumerable<VisitEntity> FindByDateOfBirth(DateTime dateOfBirth);
    }
}