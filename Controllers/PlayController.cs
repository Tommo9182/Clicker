using Microsoft.AspNetCore.Mvc;
using Clicker.Models;
using System.Diagnostics;
using Clicker.Data;
using System.Text;
using System.Text.Json;

namespace Clicker.Controllers
{
    public class PlayController : Controller
    {

		private readonly ApplicationDbContext _dbContext;

		public PlayController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StoreResults(Score scoreData)
        {
            if (scoreData == null)
            {
                return BadRequest("No Available Score");
            }

            string serializedScore = JsonSerializer.Serialize(scoreData);

            byte[] serializedBytes = Encoding.UTF8.GetBytes(serializedScore);

            HttpContext.Session.Set("savedScore", serializedBytes);

            return Ok(new { message = "Score saved successfully" });
        }

        [HttpGet]
        public IActionResult Results()
        {
            byte[]? serializedBytes = HttpContext.Session.Get("savedScore");

            if (serializedBytes != null && serializedBytes.Length > 0)
            {
                string serializedScore = Encoding.UTF8.GetString(serializedBytes);

                Score? savedScore = JsonSerializer.Deserialize<Score>(serializedScore);

                HttpContext.Session.Remove("savedScore");

                if (savedScore != null)
                {
                    ViewBag.LeaderboardPlace = GetLeaderboardRank(savedScore);
                    ViewBag.Score = savedScore;

                    return View();
                }
                
            }

            ViewBag.Score = null;
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

				return scores.Count + 1;

			}
			catch (Exception ex)
			{
				Debug.WriteLine("Exception: " + ex.ToString());
				return 0;
			}
		}
	}
}
