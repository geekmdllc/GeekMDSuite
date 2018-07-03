using GeekMDSuite.WebAPI.Presentation;
using GeekMDSuite.WebAPI.Presentation.ErrorPayload;
using Microsoft.Extensions.Configuration;

namespace GeekMDSuite.WebAPI.DataAccess.Services
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