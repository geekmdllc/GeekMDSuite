using System;

namespace GeekMDSuite.WebAPI.Core.Models
{
    public interface IVisitData : IEntity
    {
        Guid VisitGuid { get; set; }
    }
}