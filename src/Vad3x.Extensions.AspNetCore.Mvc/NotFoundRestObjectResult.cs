using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Microsoft.AspNetCore.Mvc
{
    [DefaultStatusCode(DefaultStatusCode)]
    public class NotFoundRestObjectResult : ProblemDetailRestObjectResult
    {
        private const int DefaultStatusCode = StatusCodes.Status404NotFound;

        public NotFoundRestObjectResult(ProblemDetails problemDetails)
            : base(problemDetails)
        {
            StatusCode = DefaultStatusCode;
            problemDetails.Status = DefaultStatusCode;
        }
    }
}
