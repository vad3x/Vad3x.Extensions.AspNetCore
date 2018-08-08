using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Mvc
{
    public class GoneRestObjectResult : RestObjectResult
    {
        public GoneRestObjectResult(string type, string title, string instance)
            : base(StatusCodes.Status410Gone, type, title, instance)
        {
        }
    }
}
