using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using GeekMDSuite.Core.Builders;
using GeekMDSuite.WebAPI.Core.Presentation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Text.Encodings.Web.Utf8;
using Microsoft.Extensions.Configuration;

namespace GeekMDSuite.WebAPI.Presentation
{
    public class ErrorPayload
    {
        public ErrorPayloadCode ErrorCode { get; set; }
        public string InfoUrl { get; set; }
        public string InternalMessage { get; set; }
        public string UserMessage { get; set; }

        public override string ToString() => $"Error: {ErrorCode}({ErrorCode.Value()}). Message: {InternalMessage}. InfoUrL: {InfoUrl}";
    }

}