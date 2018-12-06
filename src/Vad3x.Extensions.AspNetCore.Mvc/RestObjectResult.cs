namespace Microsoft.AspNetCore.Mvc
{
    public abstract class RestObjectResult : ObjectResult
    {
        protected RestObjectResult(int statusCode, string type, string title, string instance)
            : base(new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Type = type,
                Instance = instance
            })
        {
            Type = type;
            Title = title;
            Instance = instance;

            StatusCode = statusCode;
            DeclaredType = typeof(ProblemDetails);
        }

        public string Type { get; }
        public string Title { get; }
        public string Instance { get; }
    }
}
