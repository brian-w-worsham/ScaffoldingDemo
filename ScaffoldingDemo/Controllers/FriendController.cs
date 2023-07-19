using Microsoft.AspNetCore.Mvc;
using ScaffoldingDemo.Models;

namespace ScaffoldingDemo.Controllers
{
    public class FriendController : Controller
    {
        private readonly ToDoDbContext _dbContext;

        public FriendController(ToDoDbContext toDoDbContext)
        {
            _dbContext= toDoDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Details(Friend friend)
        {
            _dbContext.Friend.Add(friend);
            _dbContext.SaveChanges();
            return View();
        }
    }
}
