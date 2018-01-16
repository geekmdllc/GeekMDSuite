using GeekMDSuite.WebAPI.Core.Presentation;

namespace GeekMDSuite.WebAPI.Presentation.ErrorPayload
{
    public static class ErrorPayloadExtensions
    {
        public static int Value(this ErrorPayloadErrorCode code)
        {
            return (int) code;
        }
    }
}