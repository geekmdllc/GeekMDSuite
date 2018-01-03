using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.DataAccess.Context;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity<T>
    {
        public Repository() { }
        public Repository(GeekMdSuiteDbContext context)
        {
            Context = context;
        }
        
        public IEnumerable<T> All() => Context.Set<T>();

        public T FindById(int id)
        {
            try
            {
                return All().First(p => p.Id == id);
            }
            catch (Exception)
            {
                throw new RepositoryElementNotFoundException(id);
            }
        }
        
        public void Add(T entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));

            if (Context.Set<T>().Find(entity.Id) != null)
                throw new EntityNotUniqeException(entity.Id);
            
            Context.Set<T>().Add(entity);
        }

        public void Delete(int id)
        {
            var entity = FindById(id);
            
            Context.Set<T>().Remove(entity);
        }
       
        public void Update(T entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));            
            FindById(entity.Id)?.MapValues(entity);
        }
        
        

        protected readonly GeekMdSuiteDbContext Context;
    }
}