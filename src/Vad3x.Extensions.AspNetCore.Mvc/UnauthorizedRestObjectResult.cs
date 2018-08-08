using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Mvc
{
    public class UnauthorizedRestObjectResult : RestObjectResult
    {
        public UnauthorizedRestObjectResult(string type, string title, string instance)
            : base(StatusCodes.Status401Unauthorized, type, title, instance)
        {
        }
    }
}
