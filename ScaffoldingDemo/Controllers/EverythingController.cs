using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ScaffoldingDemo.Controllers
{
    public class EverythingController : Controller
    {
        public IActionResult Index()
        {
            System.Diagnostics.Debug.WriteLine($"Update link on page : {Request.GetDisplayUrl}");
            return View();
        }
    }
}
