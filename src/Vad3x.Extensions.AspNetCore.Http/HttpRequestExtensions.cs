namespace Microsoft.AspNetCore.Http
{
    public static class HttpRequestExtensions
    {
        public static string GetClientIpAddress(this HttpRequest request)
        {
            return request.HttpContext.Connection.RemoteIpAddress.ToString();
        }

        public static string GetConnectionId(this HttpRequest request)
        {
            return request.HttpContext.Connection.Id;
        }

        public static string GetRequestId(this HttpRequest request)
        {
            return request.Headers.FirstOrDefault("X-Request-ID");
        }

        public static string GetUserAgent(this HttpRequest request)
        {
            return request.Headers.FirstOrDefault("User-Agent");
        }
    }
}
