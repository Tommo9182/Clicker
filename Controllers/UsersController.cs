using Clicker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Clicker.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

		[HttpGet]
		public new async Task<IActionResult> User(string username)
		{

            ViewBag.Username = username;

			try
			{
				ApplicationUser? user = await _userManager.Users
					.Include(u => u.Scores)
                    .SingleOrDefaultAsync(u => u.UserName == username);

				if (user != null)
				{
					ViewBag.UserFound = true;
					ViewBag.User = user;
					ViewBag.Scores = user.Scores;
					Debug.WriteLine("Hello"+user.Scores.Count);


				}
				return View();

            }
			catch (Exception ex)
			{
                Debug.WriteLine("Exception: " + ex.ToString());
                return BadRequest("Error retrieving scores");
            }
		}
	}
}
