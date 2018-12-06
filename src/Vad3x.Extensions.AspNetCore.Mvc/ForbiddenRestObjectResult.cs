using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Microsoft.AspNetCore.Mvc
{
    [DefaultStatusCode(DefaultStatusCode)]
    public class ForbiddenRestObjectResult : RestObjectResult
    {
        private const int DefaultStatusCode = StatusCodes.Status403Forbidden;

        public ForbiddenRestObjectResult(string type, string title, string instance)
            : base(DefaultStatusCode, type, title, instance)
        {
        }
    }
}
