using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Microsoft.AspNetCore.Mvc
{
    [DefaultStatusCode(DefaultStatusCode)]
    public class GoneRestObjectResult : ProblemDetailRestObjectResult
    {
        private const int DefaultStatusCode = StatusCodes.Status410Gone;

        public GoneRestObjectResult(ProblemDetails problemDetails)
            : base(problemDetails)
        {
            StatusCode = DefaultStatusCode;
            problemDetails.Status = DefaultStatusCode;
        }
    }
}
