using GeekMDSuite.WebAPI.Core.Presentation;

namespace GeekMDSuite.WebAPI.Presentation
{
    public class ErrorPayload
    {
        public ErrorPayloadCode ErrorCode { get; set; }
        public string InfoUrl { get; set; }
        public string InternalMessage { get; set; }
        public string UserMessage { get; set; }

        public override string ToString()
        {
            return $"Error: {ErrorCode}({ErrorCode.Value()}). Message: {InternalMessage}. InfoUrL: {InfoUrl}";
        }
    }
}