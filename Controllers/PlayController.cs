using Microsoft.AspNetCore.Mvc;

namespace Clicker.Controllers
{
    public class PlayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
