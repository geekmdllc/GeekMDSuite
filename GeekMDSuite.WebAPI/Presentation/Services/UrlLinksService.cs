using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.Configuration;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace GeekMDSuite.WebAPI.Presentation.Services
{
    public interface IUrlLinksService
    {
        string DisplayUrl { get; }
        string CreateDisplayUrlWithAppendedRoute(string route);
        string BackOne { get; }
        string Host { get; }
    }

    public class UrlLinksService : IUrlLinksService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UrlLinksService(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor = contextAccessor;
        }

        public string DisplayUrl => GetCurrentDirectory();

        public string CreateDisplayUrlWithAppendedRoute(string route) => AddToRelativeDirectory(route);

        public string BackOne => GetBackOneRelativeDirectory();

        private string GetCurrentDirectory() => string.Join("", _httpContextAccessor.HttpContext.Request.GetUri().Segments.ToList());

        private string GetBackOneRelativeDirectory()
        {
            var uriSegments = _httpContextAccessor.HttpContext.Request.GetUri().Segments.ToList();
            var last = uriSegments.Last();
            uriSegments.Remove(last);
            return string.Join("", uriSegments);
        }
        
        private string AddToRelativeDirectory(string added)
        {
            var uriSegments = _httpContextAccessor.HttpContext.Request.GetUri().Segments.ToList();
            uriSegments.Add(added);
            return string.Join("", uriSegments);
        }

        public string Host => _httpContextAccessor.HttpContext.Request.GetUri().Host;
    }
}