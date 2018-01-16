using System;
using System.Text;
using GeekMDSuite.Utilities.Extensions;
using GeekMDSuite.WebAPI.Core.Presentation;

namespace GeekMDSuite.WebAPI.Presentation.ErrorPayload
{
    public class ErrorPayloadBuilder 
    {
        public ErrorPayload Build()
        {
            ValidatePreBuildState();
            return _payload;
        }

        public ErrorPayloadBuilder HasErrorCode(ErrorPayloadErrorCode errorCode)
        {
            _errorCodeIsSet = true;
            _payload.ErrorCode = errorCode;
            _payload.Href = _baseUrl + errorCode.Value();
            return this;
        }

        public ErrorPayloadBuilder HasInternalMessage(string message)
        {
            _payload.InternalMessage = $"{DateTime.Now.ToLongTimeString()} - {message}";
            return this;
        }

        public ErrorPayloadBuilder TellsUser(string message)
        {
            _payload.UserMessage = message;
            return this;
        }

        private ErrorPayloadBuilder()
        {
            _payload = new ErrorPayload();
        }
        
        public ErrorPayloadBuilder(string baseUrl) : this()
        {
            _baseUrl = baseUrl;
        }

        private readonly ErrorPayload _payload;
        private bool _errorCodeIsSet;
        private readonly string _baseUrl;

        private void ValidatePreBuildState()
        {
            var builder = new StringBuilder();
            if (_payload.InternalMessage.IsEmpty()) builder.Append(nameof(HasInternalMessage));
            if (_payload.UserMessage.IsEmpty()) builder.Append(nameof(TellsUser));
            if (!_errorCodeIsSet) builder.Append(nameof(HasErrorCode));

            var message = builder.ToString();
            if (message.IsNotNullOrEmpty())
                throw new MissingMethodException(message);

        }
    }
}