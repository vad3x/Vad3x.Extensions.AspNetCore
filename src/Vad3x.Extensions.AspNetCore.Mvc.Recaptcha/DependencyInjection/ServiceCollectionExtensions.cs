using Microsoft.AspNetCore.Mvc.Recaptcha;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRecaptcha(this IServiceCollection services, Action<RecaptchaOptions> configure)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            services.Configure(configure);

            services.AddTransient<ICaptchaService, RecaptchaService>();

            return services;
        }
    }
}
