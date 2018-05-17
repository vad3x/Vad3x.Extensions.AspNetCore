using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System;

namespace Microsoft.AspNetCore.Mvc.Recaptcha
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseRequestRecaptcha(this IApplicationBuilder builder, RequestRecaptchaOptions options)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return builder.UseMiddleware<RequestRecaptchaMiddleware>(Options.Create(options));
        }
    }
}
