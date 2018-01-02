using System;
using System.Collections.Generic;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Repositories
{
    public interface IVisitsRepository : IRepositoryAssociatedWithVisit<VisitEntity>
    {
        IEnumerable<VisitEntity> FindByMedicalRecordNumber(string mrn);
        IEnumerable<VisitEntity> FindByName(string name);
        IEnumerable<VisitEntity> FindByDateOfBirth(DateTime dateOfBirth);
    }
}