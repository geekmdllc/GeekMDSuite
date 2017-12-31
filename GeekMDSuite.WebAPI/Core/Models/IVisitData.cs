using System;

namespace GeekMDSuite.WebAPI.Core.Models
{
    public interface IVisitData<in TInherited> : IEntity<TInherited>
    {
        Guid Visit { get; set; }
    }
}