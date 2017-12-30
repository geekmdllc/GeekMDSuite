namespace GeekMDSuite.WebAPI.Models
{
    public interface IEntity<T> : IMapProperties<T>
    {
        int Id { get; set; }
    }
}