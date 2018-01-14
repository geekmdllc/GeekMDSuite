using GeekMDSuite.WebAPI.Core.Presentation;

namespace GeekMDSuite.WebAPI.Presentation
{
    public static class ErrorPayloadExtensions
    {
        public static int Value(this ErrorPayloadCode code)
        {
            return (int) code;
        }
    }
}