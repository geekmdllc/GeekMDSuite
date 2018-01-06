using System;
using GeekMDSuite.Core.Models;

namespace GeekMDSuite.WebAPI.Core.Models
{
    public interface IVisitData<in TInherited> : IEntity<TInherited>
    {
        Guid VisitId { get; set; }
    }
}