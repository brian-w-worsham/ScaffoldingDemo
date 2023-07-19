using Microsoft.AspNetCore.Mvc.Filters;

namespace ScaffoldingDemo
{
    public class SampleAsyncActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // throw new NotImplementedException();

            // Do something before the action executes
            
            await next();

            // do something after the action executes
        }
    }
}
