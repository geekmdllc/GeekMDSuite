namespace GeekMDSuite.WebAPI.Models
{
    public interface IEntity<in T> : IMapProperties<T>
    {
        int Id { get; set; }
    }
}