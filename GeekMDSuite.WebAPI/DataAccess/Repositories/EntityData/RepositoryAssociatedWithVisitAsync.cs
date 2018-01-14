using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories.EntityData
{
    public class RepositoryAssociatedWithVisitAsync<T> : RepositoryAsync<T>, IRepositoryAssociatedWithVisitAsync<T>
        where T : class, IVisitData<T>
    {
        public RepositoryAssociatedWithVisitAsync(GeekMdSuiteDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<T>> FindByVisit(Guid visitGuid)
        {
            if (visitGuid == Guid.Empty)
                throw new ArgumentOutOfRangeException($"{nameof(visitGuid)} must not be an empty Guid.");

            var result = await Context.Set<T>().Where(set => set.Guid == visitGuid).ToListAsync();

            if (!result.Any())
                throw new RepositoryElementNotFoundException(visitGuid.ToString());

            return result;
        }
    }
}