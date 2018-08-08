using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Mvc
{
    public class ConflictRestObjectResult : RestObjectResult
    {
        public ConflictRestObjectResult(string type, string title, string instance)
            : base(StatusCodes.Status409Conflict, type, title, instance)
        {
        }
    }
}
