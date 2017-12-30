using System;

namespace GeekMDSuite.WebAPI.Core.Models
{
    public interface IVisitData<in T> : IEntity<T>
    {
        Guid Visit { get; set; }
    }
}