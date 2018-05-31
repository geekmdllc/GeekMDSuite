using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories.EntityData
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity>
        where TEntity : class, IMapProperties<TEntity>, IEntity
    {
        protected readonly GeekMdSuiteDbContext Context;

        public RepositoryAsync()
        {
        }

        public RepositoryAsync(GeekMdSuiteDbContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<TEntity>> All()
        {
            var results = await Context.Set<TEntity>().ToListAsync();
            if (!results.Any())
                throw new RepositoryEntityNotFoundException();

            return results;
        }

        public async Task<TEntity> FindById(int id)
        {
            try
            {
                return await Context.Set<TEntity>().Where(p => p.Id == id).FirstAsync();
            }
            catch
            {
                throw new RepositoryEntityNotFoundException(id);
            }
        }

        public async Task Add(TEntity entity)
        {
            if (typeof(TEntity) == typeof(IVisitData))
                if ((entity as IVisitData)?.VisitGuid == Guid.Empty)
                    throw new InvalidDataException(nameof(entity));

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (Context.Set<TEntity>().Find(entity.Id) != null)
                throw new EntityNotUniqeException(entity.Id);

            await Context.Set<TEntity>().AddAsync(entity);
        }


        public async Task Delete(int id)
        {
            var entity = await FindById(id);

            Context.Set<TEntity>().Remove(entity);
        }


        public async Task Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            (await FindById(entity.Id)).MapValues(entity);
        }
    }
}