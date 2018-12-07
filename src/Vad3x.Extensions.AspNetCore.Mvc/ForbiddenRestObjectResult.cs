using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Microsoft.AspNetCore.Mvc
{
    [DefaultStatusCode(DefaultStatusCode)]
    public class ForbiddenRestObjectResult : ProblemDetailRestObjectResult
    {
        private const int DefaultStatusCode = StatusCodes.Status403Forbidden;

        public ForbiddenRestObjectResult(ProblemDetails problemDetails)
            : base(problemDetails)
        {
            StatusCode = DefaultStatusCode;
            problemDetails.Status = DefaultStatusCode;
        }
    }
}
