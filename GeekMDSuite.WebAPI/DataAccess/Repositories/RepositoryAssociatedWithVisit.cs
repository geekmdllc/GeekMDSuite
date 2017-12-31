using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.DataAccess.Context;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class RepositoryAssociatedWithVisit<T> : Repository<T>, IRepositoryAssociatedWithVisit<T> where T : class, IVisitData<T>
    {
        public RepositoryAssociatedWithVisit(GeekMdSuiteDbContext context) : base (context) {}
        
        public IEnumerable<T> FindByVisit(Guid visitGuid) => Context.Set<T>().Where(v => v.Visit == visitGuid);
        
        public IEnumerable<T> FindByPatient(Guid patientGuid)
        {
            var visitsList = Context.Visits.Where(v => v.PatientGuid == patientGuid).ToList();
            var setList = new List<T>();
            foreach (var visit in visitsList)
                setList.AddRange(FindByVisit(visit.Visit));

            return setList;
        }
    }
}