using Clicker.Data;
using Clicker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Clicker.Controllers
{
	public class LeaderboardController : Controller
	{

		private readonly ApplicationDbContext _dbContext;

		public LeaderboardController(ApplicationDbContext context)
		{
			_dbContext = context;
		}

		[HttpGet]
		public IActionResult Index(int time = 0, int page = 0)
		{
			try
			{
				List<Score> scores = _dbContext.Scores
					.Where(s => s.time == time || time == 0)
					.OrderByDescending(s => s.clicksPerMinute)
					.ToList();

				ViewBag.Scores = scores;
				ViewBag.Time = time;
				ViewBag.Page = page;

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
