using System.Collections.Generic;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData
{
    public interface IRepository<T> where T : class, IEntity<T>
    {
        Task<IEnumerable<T>> All();
        Task<T> FindById(int id);
        Task Add(T entity);
        Task Delete(int id);
        Task Update(T entity);
    }
}