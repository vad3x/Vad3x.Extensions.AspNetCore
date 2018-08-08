using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Mvc
{
    public class ForbiddenRestObjectResult : RestObjectResult
    {
        public ForbiddenRestObjectResult(string type, string title, string instance)
            : base(StatusCodes.Status403Forbidden, type, title, instance)
        {
        }
    }
}
