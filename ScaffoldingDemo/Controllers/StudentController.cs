using Microsoft.AspNetCore.Mvc;

namespace ScaffoldingDemo.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        // public ActionResult Index(IFormCollection frm)
        public ActionResult Index(int StudentId, string Name, string Address, string City)
        {
            /*var studentId = frm["StudentId"].ToString();
            var name = frm["Name"].ToString();
            var address = frm["Address"].ToString();

            var city = frm["City"].ToString();
            var state = frm["State"].ToString();
            var country = frm["Country"].ToString() ;

            var department = frm["Department"].ToString();
*/

            // var name = Request.QueryString["Name"].ToString();
            return View();
        }
    }
}
