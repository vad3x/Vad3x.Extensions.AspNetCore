using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Mvc
{
    public abstract class RestController : Controller
    {
        [NonAction]
        public ConflictRestObjectResult Conflict(string type, string title = null)
        {
            return new ConflictRestObjectResult(type, title, HttpContext.Request.Path);
        }

        [NonAction]
        public GoneRestObjectResult Gone(string type, string title = null)
        {
            return new GoneRestObjectResult(type, title, HttpContext.Request.Path);
        }

        [NonAction]
        public NotFoundRestObjectResult NotFound(string type, string title = null)
        {
            return new NotFoundRestObjectResult(type, title, HttpContext.Request.Path);
        }

        [NonAction]
        public UnauthorizedRestObjectResult Unauthorized(string type, string title = null)
        {
            return new UnauthorizedRestObjectResult(type, title, HttpContext.Request.Path);
        }

        [NonAction]
        public ForbiddenRestObjectResult Forbid(string type, string title = null)
        {
            return new ForbiddenRestObjectResult(type, title, HttpContext.Request.Path);
        }
    }
}
