using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Mvc.Recaptcha
{
    public class RequestRecaptchaMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RecaptchaService _recaptchaService;
        private readonly RequestRecaptchaOptions _options;

        public RequestRecaptchaMiddleware(
            RequestDelegate next,
            RecaptchaService recaptchaService,
            IOptions<RequestRecaptchaOptions> options)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _recaptchaService = recaptchaService;
            _options = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            if (_options.ShouldApply(context.Request))
            {
                var captchaValue = context.Request.Headers.FirstOrDefault("recaptcha-code");
                if (captchaValue == null || !await _recaptchaService.IsValidAsync(captchaValue, context.Request.GetClientIpAddress()))
                {
                    // Too many requests
                    context.Response.StatusCode = 429;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(@"{ ""message"": ""'recaptcha-code' header is required"" }");
                    return;
                }
            }

            await _next(context);
        }
    }
}
