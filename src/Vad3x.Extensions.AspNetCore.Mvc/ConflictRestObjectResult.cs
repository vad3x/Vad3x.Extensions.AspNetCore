using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Microsoft.AspNetCore.Mvc
{
    [DefaultStatusCode(DefaultStatusCode)]
    public class ConflictRestObjectResult : RestObjectResult
    {
        private const int DefaultStatusCode = StatusCodes.Status409Conflict;

        public ConflictRestObjectResult(string type, string title, string instance)
            : base(DefaultStatusCode, type, title, instance)
        {
        }
    }
}
