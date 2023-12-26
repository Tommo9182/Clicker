using Clicker.Data;
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
        private readonly ApplicationDbContext _dbContext;

        public UsersController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _dbContext = context;
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

				List<Score> scores = _dbContext.Scores
					.Where(s => s.Username == username)
					.OrderByDescending(s => s.clicksPerMinute)
					.ToList();

				if (user != null)
				{
					ViewBag.UserFound = true;
					ViewBag.User = user;
					ViewBag.Scores = scores;
                    ViewBag.LeaderboardRank = GetBestLeaderboardRank(username);


				}
				return View();

            }
			catch (Exception ex)
			{
                Debug.WriteLine("Exception: " + ex.ToString());
                return BadRequest("Error retrieving scores");
            }
		}

        private int GetBestLeaderboardRank(string username)
        {
            try
            {
                List<Score> scores = _dbContext.Scores.
                    OrderByDescending(s => s.clicksPerMinute).
                    ToList();

                for(int i = 0; i < scores.Count; i++)
                {
                    if (scores[i].Username == username)
                    {
                        return i + 1;
                    }
                }

                return 0;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.ToString());
                return 0;
            }
        }
    }
}
