using Clicker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace Clicker.Controllers
{
    public class LeaderboardController : Controller
    {
        [HttpGet]
        public IActionResult Index(int time, int page)
        {
            List<Score> scores = new List<Score>();


            try
            {
                String connectionString = Globals.DatabaseConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String query = "SELECT * FROM scores";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetInt32(2) == time || time == 0)
                                {
                                    Score score = new Score();
                                    score.Id = reader.GetInt32(0);
                                    score.clicks = reader.GetInt32(1);
                                    score.time = reader.GetInt32(2);
                                    score.clicksPerMinute = 60 / reader.GetInt32(2) * reader.GetInt32(1);
                                    score.Username = reader.GetString(4);
                                    score.ApplicationUserId = reader.GetString(5);
                                    scores.Add(score);
                                }
                                
                            }
                        }
                    }
                }
                List<Score> sortedScores = scores.OrderBy(o => o.clicksPerMinute).ToList();
                sortedScores.Reverse();
                ViewBag.Scores = sortedScores;
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
