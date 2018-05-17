using Microsoft.AspNetCore.Http;
using System;

namespace Microsoft.AspNetCore.Mvc.Recaptcha
{
    public class RequestRecaptchaOptions
    {
        public Func<HttpRequest, bool> ShouldApply { get; set; } = (request) => false;
    }
}