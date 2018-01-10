using GeekMDSuite.WebAPI.Core.Presentation;

namespace GeekMDSuite.WebAPI.Presentation
{
    public class ErrorPayload
    {
        public string UserMessage { get; set; }
        public string InternalMessage { get; set; }
        public ErrorPayloadCode ErrorCode { get; set; }
        public string MoreInfo { get; set; }
    }
}