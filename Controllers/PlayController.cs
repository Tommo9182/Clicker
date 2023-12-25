using Microsoft.AspNetCore.Mvc;
using Clicker.Models;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace Clicker.Controllers
{
    public class PlayController : Controller
    {

        [HttpGet]
        public IActionResult Results(Score scoreData)
        {
            ViewBag.Score = scoreData;
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
