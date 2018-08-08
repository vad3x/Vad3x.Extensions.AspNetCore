using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Mvc
{
    public class NotFoundRestObjectResult : RestObjectResult
    {
        public NotFoundRestObjectResult(string type, string title, string instance)
            : base(StatusCodes.Status404NotFound, type, title, instance)
        {
        }
    }
}
