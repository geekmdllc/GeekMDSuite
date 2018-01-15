using Microsoft.Extensions.Configuration;

namespace GeekMDSuite.WebAPI.Presentation
{
    public class ErrorService : IErrorService
    {
        public ErrorService(IConfiguration configuration)
        {
            var baseUrl = configuration.GetSection("ErrorDocumentationBaseUrl").Value;
            PayloadBuilder = new ErrorPayloadBuilder(baseUrl);
        }
        public ErrorPayloadBuilder PayloadBuilder { get; }
    }
}