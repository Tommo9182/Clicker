using Clicker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using static System.Formats.Asn1.AsnWriter;
using System.Diagnostics;

namespace Clicker.Controllers
{
    public class ScoreController : Controller
    {
        private String connectionString = Globals.DatabaseConnectionString;

        [HttpPost]
        public IActionResult SaveScore(Score scoreData)
        {
            try
            {
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
                        command.Parameters.AddWithValue("@user", scoreData.user);
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

        [HttpDelete]
        public IActionResult Delete(int Id) {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    String query = "DELETE FROM Scores WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", Id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DELETE Exception: " + ex);
                return BadRequest("Error deleting score");
            }

            return Ok(new { message = "Score deleted successfully" });
        }

        [HttpDelete]
        public IActionResult DeleteAll()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    String query = "DELETE FROM Scores";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DELETE Exception: " + ex);
                return BadRequest("Error deleting score");
            }

            return Ok(new { message = "Score deleted successfully" });
        }
    }
}
