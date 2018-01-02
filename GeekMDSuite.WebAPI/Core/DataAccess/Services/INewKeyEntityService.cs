using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Services
{
    public interface INewKeyEntityService<out TObject, in TTemplate> 
        where TObject: class, IEntity<TObject>
        where TTemplate : class
    {
        TObject GenerateUsing(TTemplate visit);
    }
}