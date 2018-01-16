using GeekMDSuite.WebAPI.Presentation.ErrorPayload;

namespace GeekMDSuite.WebAPI.Presentation
{
    public interface IErrorService
    {
        ErrorPayloadBuilder PayloadBuilder { get; }
    }
}