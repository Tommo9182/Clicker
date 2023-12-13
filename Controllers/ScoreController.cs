using ClickerWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using static System.Formats.Asn1.AsnWriter;
using System.Diagnostics;

namespace ClickerWebApp.Controllers
{
    public class ScoreController : Controller
    {
        [HttpPost]
        public IActionResult SaveScore(Score scoreData)
        {
            Score score = new Score
            {
                name = scoreData.name,
                clicks = scoreData.clicks,
                time = scoreData.time,
                clicksPerMinute = scoreData.clicksPerMinute
            };
            Debug.WriteLine("hello"+scoreData.name.GetType() + "" + scoreData.clicks.GetType() + "" + scoreData.time.GetType() + "" + score.clicksPerMinute.GetType());
            

            //save to database
            try
            {
                String connectionString = "Data Source=.;Initial Catalog=ClickerDB;Integrated Security=True;TrustServerCertificate=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String query = "INSERT INTO Scores " +
                                   "(clicks, time, name, clicksPerMinute) VALUES" +
                                   "(@clicks, @time, @name, @clicksPerMinute);";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@clicks", scoreData.clicks);
                        command.Parameters.AddWithValue("@time", scoreData.time);
                        command.Parameters.AddWithValue("@name", scoreData.name);
                        command.Parameters.AddWithValue("@clicksPerMinute", scoreData.clicksPerMinute);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex);
                return BadRequest("Error saving score");
            }

            return Ok(new { message = "Score saved successfully" });
        }
    }
}
