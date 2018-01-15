using System;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public interface IStub
    {
        int Id { get; set; }
        Guid Guid { get; set; }
    }
}