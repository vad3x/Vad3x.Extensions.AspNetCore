using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Microsoft.AspNetCore.Mvc
{
    [DefaultStatusCode(DefaultStatusCode)]
    public class UnauthorizedRestObjectResult : ProblemDetailRestObjectResult
    {
        private const int DefaultStatusCode = StatusCodes.Status401Unauthorized;

        public UnauthorizedRestObjectResult(ProblemDetails problemDetails)
            : base(problemDetails)
        {
            StatusCode = DefaultStatusCode;
            problemDetails.Status = DefaultStatusCode;
        }
    }
}
