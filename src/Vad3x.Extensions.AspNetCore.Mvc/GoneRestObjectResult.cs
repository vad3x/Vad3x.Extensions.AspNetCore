using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Microsoft.AspNetCore.Mvc
{
    [DefaultStatusCode(DefaultStatusCode)]
    public class GoneRestObjectResult : RestObjectResult
    {
        private const int DefaultStatusCode = StatusCodes.Status410Gone;

        public GoneRestObjectResult(string type, string title, string instance)
            : base(DefaultStatusCode, type, title, instance)
        {
        }
    }
}
