using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Mvc
{
    public abstract class RestController : Controller
    {
        [NonAction]
        public ConflictRestObjectResult Conflict(ProblemDetails problemDetails)
        {
            problemDetails.Instance = HttpContext.Request.Path;

            return new ConflictRestObjectResult(problemDetails);
        }

        [NonAction]
        public GoneRestObjectResult Gone(ProblemDetails problemDetails)
        {
            problemDetails.Instance = HttpContext.Request.Path;

            return new GoneRestObjectResult(problemDetails);
        }

        [NonAction]
        public NotFoundRestObjectResult NotFound(ProblemDetails problemDetails)
        {
            problemDetails.Instance = HttpContext.Request.Path;

            return new NotFoundRestObjectResult(problemDetails);
        }

        [NonAction]
        public UnauthorizedRestObjectResult Unauthorized(ProblemDetails problemDetails)
        {
            problemDetails.Instance = HttpContext.Request.Path;

            return new UnauthorizedRestObjectResult(problemDetails);
        }

        [NonAction]
        public ForbiddenRestObjectResult Forbid(ProblemDetails problemDetails)
        {
            problemDetails.Instance = HttpContext.Request.Path;

            return new ForbiddenRestObjectResult(problemDetails);
        }
    }
}
