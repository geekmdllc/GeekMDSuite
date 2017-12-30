using System;
using System.Linq;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.DataAccess.Context;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class RepositoryAssociatedWithVisit<T> : Repository<T>, IRepositoryAssociatedWithVisit<T> where T : class, IVisitData<T>
    {
        public RepositoryAssociatedWithVisit(GeekMdSuiteDbContext context) : base (context) {}
        
        public T FindByVisit(Guid visitGuid) => Context.Set<T>().First(v => v.Visit == visitGuid);
    }
}