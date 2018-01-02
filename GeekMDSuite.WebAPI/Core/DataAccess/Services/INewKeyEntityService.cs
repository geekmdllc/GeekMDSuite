using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.DataAccess.Context;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Services
{
    public interface INewKeyEntityService<out TObject, in TTemplate> 
        where TObject: class, IEntity<TObject>
        where TTemplate : class
    {
        INewKeyEntityService<TObject, TTemplate> WithUnitOfWork(IUnitOfWork unitOfWork);
        TObject GenerateUsing(TTemplate visit);
    }
}