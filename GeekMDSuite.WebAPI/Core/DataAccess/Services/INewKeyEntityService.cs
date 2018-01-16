using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Services
{
    public interface INewKeyEntityService<TObject, TTemplate>
        where TObject : class, IEntity
        where TTemplate : class
    {
        INewKeyEntityService<TObject, TTemplate> WithUnitOfWork(IUnitOfWork unitOfWork);
        Task<TObject> UsingTemplatePatientEntity(TTemplate visit);
    }
}