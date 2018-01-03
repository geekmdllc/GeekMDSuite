using System.Collections.Generic;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData
{
    public interface IRepository<T> where T : class, IEntity<T>
    {
        IEnumerable<T> All();
        T FindById(int id);
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
    }
}