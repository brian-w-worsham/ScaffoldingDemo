using Microsoft.AspNetCore.Mvc.Filters;

namespace ScaffoldingDemo
{
    public class SampleActionFilter : ActionFilterAttribute
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"{nameof(SampleActionFilter)}");
            base.OnActionExecuted(context);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"{nameof(SampleActionFilter)}");
            base.OnActionExecuting(context);
        }
    }
}
