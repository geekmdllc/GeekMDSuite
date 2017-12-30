using System;
using System.Collections.Generic;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class VisitsRepository : Repository<VisitEntity>, IVisitRepository
    {
        public VisitsRepository(GeekMdSuiteDbContext context) : base (context) {}
        
        public IEnumerable<VisitEntity> FindByPatientGuid(Guid patientGuid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VisitEntity> FindByMedicalRecordNumber(string mrn)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VisitEntity> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VisitEntity> FindByDateOfBirth(DateTime dateOfBirth)
        {
            throw new NotImplementedException();
        }
    }
}