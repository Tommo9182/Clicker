using Microsoft.AspNetCore.Mvc;

namespace Clicker.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
