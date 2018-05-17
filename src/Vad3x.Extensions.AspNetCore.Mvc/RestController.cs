using System.Net;

namespace Microsoft.AspNetCore.Mvc
{
    public abstract class RestController : Controller
    {
        [NonAction]
        public IActionResult Conflict(string message = null, string errorCode = null)
        {
            return GeneralResponse(HttpStatusCode.Conflict, message, errorCode);
        }

        [NonAction]
        public IActionResult Gone(string message, string errorCode = null)
        {
            return GeneralResponse(HttpStatusCode.Gone, message, errorCode);
        }

        [NonAction]
        public IActionResult NotFound(string message, string errorCode = null)
        {
            return GeneralResponse(HttpStatusCode.NotFound, message, errorCode);
        }

        [NonAction]
        public IActionResult Unauthorized(string message, string errorCode = null)
        {
            return GeneralResponse(HttpStatusCode.Unauthorized, message, errorCode);
        }

        [NonAction]
        public IActionResult Forbid(string message, string errorCode = null)
        {
            return GeneralResponse(HttpStatusCode.Forbidden, message, errorCode);
        }

        private IActionResult GeneralResponse(HttpStatusCode statusCode, string message = null, string errorCode = null)
        {
            return StatusCode((int)statusCode, new GeneralData
            {
                Message = message,
                ErrorCode = errorCode
            });
        }
    }
}
