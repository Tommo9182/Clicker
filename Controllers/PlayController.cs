using Microsoft.AspNetCore.Mvc;
using Clicker.Models;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Clicker.Data;

namespace Clicker.Controllers
{
    public class PlayController : Controller
    {

		private readonly ApplicationDbContext _dbContext;

		public PlayController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

        [HttpGet]
        public IActionResult Results(Score scoreData)
        {
			ViewBag.LeaderboardPlace = GetLeaderboardRank(scoreData);
            ViewBag.Score = scoreData;
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

		private int GetLeaderboardRank(Score score)
		{
			try
			{
				List<Score> scores = _dbContext.Scores.
					OrderByDescending(s => s.clicksPerMinute).
					ToList();

				for (int i = 0; i < scores.Count; i++)
				{
					if(score.clicksPerMinute >= scores[i].clicksPerMinute)
					{
						return i + 1;
					}					
				}

				return scores.Count;

			}
			catch (Exception ex)
			{
				Debug.WriteLine("Exception: " + ex.ToString());
				return 0;
			}
		}
	}
}
