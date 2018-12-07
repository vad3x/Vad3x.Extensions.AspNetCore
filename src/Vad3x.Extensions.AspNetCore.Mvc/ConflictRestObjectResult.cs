using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Microsoft.AspNetCore.Mvc
{
    [DefaultStatusCode(DefaultStatusCode)]
    public class ConflictRestObjectResult : ProblemDetailRestObjectResult
    {
        private const int DefaultStatusCode = StatusCodes.Status409Conflict;

        public ConflictRestObjectResult(ProblemDetails problemDetails)
            : base(problemDetails)
        {
            StatusCode = DefaultStatusCode;
            problemDetails.Status = DefaultStatusCode;
        }
    }
}
