using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.WebAPI.Exceptions;
using GeekMDSuite.WebAPI.Models;
using GeekMDSuite.WebAPI.Persistence;

namespace GeekMDSuite.WebAPI.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity<T>
    {
        public Repository(GeekMdSuiteDbContext context)
        {
            Context = context;
        }
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
        
        protected readonly GeekMdSuiteDbContext Context;

        public Repository() { }
    }
}