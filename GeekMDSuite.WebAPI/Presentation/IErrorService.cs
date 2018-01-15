namespace GeekMDSuite.WebAPI.Presentation
{
    public interface IErrorService
    {
        ErrorPayloadBuilder PayloadBuilder { get; }
    }
}