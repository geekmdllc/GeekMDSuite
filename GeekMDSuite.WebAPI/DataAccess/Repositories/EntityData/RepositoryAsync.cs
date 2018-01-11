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
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class, IEntity<T>
    {
        protected readonly GeekMdSuiteDbContext Context;

        public RepositoryAsync()
        {
        }

        public RepositoryAsync(GeekMdSuiteDbContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<T>> All()
        {
            var results = await Context.Set<T>().ToListAsync();
            if (!results.Any())
                throw new RepositoryElementNotFoundException();

            return results;
        }

        public async Task<T> FindById(int id)
        {
            try
            {
                return await Context.Set<T>().Where(p => p.Id == id).FirstAsync();
            }
            catch
            {
                throw new RepositoryElementNotFoundException(id);
            }
        }

        public async Task Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (Context.Set<T>().Find(entity.Id) != null)
                throw new EntityNotUniqeException(entity.Id);

            await Context.Set<T>().AddAsync(entity);
        }


        public async Task Delete(int id)
        {
            var entity = await FindById(id);

            Context.Set<T>().Remove(entity);
        }


        public async Task Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            (await FindById(entity.Id)).MapValues(entity);
        }
    }
}