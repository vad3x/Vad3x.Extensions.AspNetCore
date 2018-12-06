using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Microsoft.AspNetCore.Mvc
{
    [DefaultStatusCode(DefaultStatusCode)]
    public class NotFoundRestObjectResult : RestObjectResult
    {
        private const int DefaultStatusCode = StatusCodes.Status404NotFound;

        public NotFoundRestObjectResult(string type, string title, string instance)
            : base(DefaultStatusCode, type, title, instance)
        {
        }
    }
}
