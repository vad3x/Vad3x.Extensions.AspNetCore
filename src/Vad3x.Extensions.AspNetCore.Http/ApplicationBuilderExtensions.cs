using System;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseGlobalErrorHandling(this IApplicationBuilder app, ILogger errorLogger)
        {
            app.Use(async (context, next) =>
            {
                try
                {
                    await next.Invoke();
                }
                catch (Exception ex)
                {
                    if (ex is OperationCanceledException)
                    {
                        throw;
                    }

                    var traceId = context.Request.GetRequestId();
                    var errorFormat = "Unhandled exception processing traceId: {traceId}";

                    errorLogger.LogError(ex, errorFormat, traceId);

                    if (!context.Response.HasStarted)
                    {
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync($"{{ \"message\": \"Internal Error\", \"traceId\": \"{traceId}\" }}");
                    }
                }
            });
        }

        public static void UseForwardedServerInfo(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                var request = context.Request;

                var scheme = request.Headers.FirstOrDefault("X-Forwarded-Proto");
                if (scheme != null)
                {
                    request.Scheme = scheme;
                }

                var host = request.Headers.FirstOrDefault("X-Forwarded-Host");
                if (host != null)
                {
                    request.Host = new HostString(host);
                }

                var prefix = request.Headers.FirstOrDefault("X-Forwarded-Prefix");
                if (prefix != null)
                {
                    request.PathBase = prefix;
                }

                var pathBase = request.Headers.FirstOrDefault("X-Forwarded-Path");
                if (pathBase != null)
                {
                    request.PathBase = pathBase;
                }

                await next.Invoke();
            });
        }

        public static void UseRealRemoteIp(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                var realIp = context.Request.Headers.FirstOrDefault("X-Real-IP");
                if (realIp != null)
                {
                    context.Connection.RemoteIpAddress = System.Net.IPAddress.Parse(realIp);
                }

                await next.Invoke();
            });
        }
    }
}

