using System.Collections.Generic;
using GeekMDSuite.WebAPI.Models;

namespace GeekMDSuite.WebAPI.Repositories
{
    public interface IRepository<T> where T : IEntity<T>
    {
        T FindById(int id);
        IEnumerable<T> All();
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
    }
}