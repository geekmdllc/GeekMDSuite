using System;

namespace GeekMDSuite.WebAPI.Models
{
    public interface IVisitData<in T> : IEntity<T>
    {
        Guid Visit { get; set; }
    }
}