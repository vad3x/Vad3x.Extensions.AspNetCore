namespace Microsoft.AspNetCore.Mvc
{
    public abstract class ProblemDetailRestObjectResult : ObjectResult
    {
        protected ProblemDetailRestObjectResult(ProblemDetails problemDetails)
            : base(problemDetails)
        {
            ProblemDetails = problemDetails;

            ContentTypes = new Formatters.MediaTypeCollection { "application/problem+json", "application/problem+xml" };
        }

        public ProblemDetails ProblemDetails { get; }
    }
}
