using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class RepositoryAssociatedWithVisit<T> : Repository<T>, IRepositoryAssociatedWithVisit<T> 
        where T : class, IVisitData<T>
    {
        public RepositoryAssociatedWithVisit(GeekMdSuiteDbContext context) : base (context) {}

        public IEnumerable<T> FindByVisit(Guid visitGuid)
        {
            if (visitGuid == Guid.Empty) 
                throw new ArgumentOutOfRangeException($"{nameof(visitGuid)} must not be an empty Guid.");

            var result = Context.Set<T>().Where(v => v.Visit == visitGuid);
            
            if (!result.Any())
                throw new RepositoryElementNotFoundException(visitGuid.ToString());

            return result;
        }
        
        public IEnumerable<T> FindByPatientGuid(Guid patientGuid)
        {
            if (patientGuid == Guid.Empty) 
                throw new ArgumentOutOfRangeException($"{nameof(patientGuid)} must not be an empty Guid.");
            
            var visitsList = Context.Visits.Where(v => v.PatientGuid == patientGuid).ToList();
            if (!visitsList.Any())
                throw new RepositoryElementNotFoundException(patientGuid.ToString());

            if (typeof(T) == typeof(VisitEntity))
                return visitsList as IEnumerable<T>;
            
            var results = new List<T>();
            foreach (var visit in visitsList)
                results.AddRange(FindByVisit(visit.Visit));

            if (!results.Any())
                throw new RepositoryElementNotFoundException(patientGuid.ToString());
            
            return results;
        }
    }
}