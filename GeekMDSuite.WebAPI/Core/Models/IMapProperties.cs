namespace GeekMDSuite.WebAPI.Core.Models
{
    public interface IMapProperties<in T> 
    {
        void MapValues(T subject);
    }
}