using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData
{
    public interface IRepositoryAsync<T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T> FindById(int id);
        Task Add(T entity);
        Task Delete(int id);
        Task Update(T entity);
    }
}