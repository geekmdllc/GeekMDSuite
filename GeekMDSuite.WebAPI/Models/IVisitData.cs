using System;

namespace GeekMDSuite.WebAPI.Models
{
    public interface IVisitData : IEntity
    {
        Guid Visit { get; set; }
    }
}