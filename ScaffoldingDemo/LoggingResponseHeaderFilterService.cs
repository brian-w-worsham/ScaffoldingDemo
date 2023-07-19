using Microsoft.AspNetCore.Mvc.Filters;

namespace ScaffoldingDemo
{
    public class LoggingResponseHeaderFilterService : IResultFilter
    {
        private readonly ILogger _logger;
        private string headerName;
        private string headerValue;

       
        public LoggingResponseHeaderFilterService(ILogger<LoggingResponseHeaderFilterService> logger) => _logger = logger;

        public void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation(
           $"- {nameof(LoggingResponseHeaderFilterService)}.{nameof(OnResultExecuted)}");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation(
            $"- {nameof(LoggingResponseHeaderFilterService)}.{nameof(OnResultExecuting)}");

            context.HttpContext.Response.Headers.Add(
                nameof(OnResultExecuting), nameof(LoggingResponseHeaderFilterService));
        }
    }
}
