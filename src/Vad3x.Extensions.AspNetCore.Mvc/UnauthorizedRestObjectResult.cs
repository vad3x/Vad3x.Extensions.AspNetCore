using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Microsoft.AspNetCore.Mvc
{
    [DefaultStatusCode(DefaultStatusCode)]
    public class UnauthorizedRestObjectResult : RestObjectResult
    {
        private const int DefaultStatusCode = StatusCodes.Status401Unauthorized;

        public UnauthorizedRestObjectResult(string type, string title, string instance)
            : base(DefaultStatusCode, type, title, instance)
        {
        }
    }
}
