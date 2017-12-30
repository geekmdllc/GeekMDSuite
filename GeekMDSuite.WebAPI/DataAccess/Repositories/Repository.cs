using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Repositories;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity<T>
    {
        public T FindById(int id)
        {
            try 
            {
                return Context.Set<T>().First(p => p.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<T> All() => Context.Set<T>();

        public void Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Context.Set<T>().Add(entity);
        }

        public void Delete(int id)
        {
            var patient = FindById(id);
            if (patient == null) throw new RepositoryElementNotFoundException(nameof(patient));
            Context.Set<T>().Remove(patient);
            
        }
       
        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            
            FindById(entity.Id)?.MapValues(entity);
        }
        
        public Repository(GeekMdSuiteDbContext context)
        {
            Context = context;
        }

        public Repository() { }
        
        protected readonly GeekMdSuiteDbContext Context;
    }
}