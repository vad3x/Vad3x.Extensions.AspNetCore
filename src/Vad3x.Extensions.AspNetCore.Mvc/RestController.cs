using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Mvc
{
    public abstract class RestController : Controller
    {
        [NonAction]
        public ActionResult Conflict(string type, string title = null)
        {
            return new ConflictRestObjectResult(type, title, HttpContext.Request.Path);
        }

        [NonAction]
        public ActionResult Gone(string type, string title = null)
        {
            return new GoneRestObjectResult(type, title, HttpContext.Request.Path);
        }

        [NonAction]
        public ActionResult NotFound(string type, string title = null)
        {
            return new NotFoundRestObjectResult(type, title, HttpContext.Request.Path);
        }

        [NonAction]
        public ActionResult Unauthorized(string type, string title = null)
        {
            return new UnauthorizedRestObjectResult(type, title, HttpContext.Request.Path);
        }

        [NonAction]
        public ActionResult Forbid(string type, string title = null)
        {
            return new ForbiddenRestObjectResult(type, title, HttpContext.Request.Path);
        }
    }
}
