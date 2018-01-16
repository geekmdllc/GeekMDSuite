using GeekMDSuite.WebAPI.Core.Presentation;

namespace GeekMDSuite.WebAPI.Presentation.ErrorPayload
{
    public class ErrorPayload
    {
        public ErrorPayloadErrorCode ErrorCode { get; set; }
        public string Href { get; set; }
        public string InternalMessage { get; set; }
        public string UserMessage { get; set; }

        public override string ToString()
        {
            return $"Error: {ErrorCode}({ErrorCode.Value()}). Message: {InternalMessage}. InfoUrL: {Href}";
        }
    }
}