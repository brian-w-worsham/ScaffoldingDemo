using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ScaffoldingDemo.Models;
using System.Diagnostics;

namespace ScaffoldingDemo.Controllers
{
    // [SampleActionFilter(Order = int.MinValue)]
    // [ServiceFilter(typeof(LoggingResponseHeaderFilterService))]
    [TypeFilter(typeof(LoggingResponseHeaderFilterService))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine(
            $"- {nameof(HomeController)}.{nameof(OnActionExecuting)}");

            base.OnActionExecuting(context);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine(
            $"- {nameof(HomeController)}.{nameof(OnActionExecuted)}");
            base.OnActionExecuted(context);
        }
    }
}