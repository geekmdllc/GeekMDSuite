using System;

namespace GeekMDSuite.WebAPI.Models
{
    public interface IVisitData<T> : IEntity<T>
    {
        Guid Visit { get; set; }
    }
}