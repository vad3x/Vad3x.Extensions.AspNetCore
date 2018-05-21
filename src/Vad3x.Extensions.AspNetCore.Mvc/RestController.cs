using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Mvc
{
    public abstract class RestController : Controller
    {
        [NonAction]
        public IActionResult Conflict(string type, string title = null)
        {
            return GeneralResponse(StatusCodes.Status409Conflict, type, title);
        }

        [NonAction]
        public IActionResult Gone(string type, string title = null)
        {
            return GeneralResponse(StatusCodes.Status410Gone, type, title);
        }

        [NonAction]
        public IActionResult NotFound(string type, string title = null)
        {
            return GeneralResponse(StatusCodes.Status404NotFound, type, title);
        }

        [NonAction]
        public IActionResult Unauthorized(string type, string title = null)
        {
            return GeneralResponse(StatusCodes.Status401Unauthorized, type, title);
        }

        [NonAction]
        public IActionResult Forbid(string type, string title = null)
        {
            return GeneralResponse(StatusCodes.Status403Forbidden, type, title);
        }

        private IActionResult GeneralResponse(int statusCode, string type, string title)
        {
            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Type = type,
                Instance = HttpContext.Request.Path
            };

            return new ObjectResult(problemDetails)
            {
                StatusCode = statusCode
            };
        }
    }
}
