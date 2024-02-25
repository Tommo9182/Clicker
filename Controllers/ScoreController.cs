using Clicker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using static System.Formats.Asn1.AsnWriter;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Clicker.Data;
using Microsoft.EntityFrameworkCore;

namespace Clicker.Controllers
{
    public class ScoreController : Controller
    {
        private String connectionString = Globals.DatabaseConnectionString;

        private readonly ApplicationDbContext _dbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public ScoreController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _dbContext = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

		[HttpPost]
        public IActionResult SaveScore(Score scoreData)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String query = "INSERT INTO Scores " +
                                   "(clicks, time, username, ApplicationUserId, clicksPerMinute) VALUES" +
                                   "(@clicks, @time, @username, @ApplicationUserId, @clicksPerMinute);";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@clicks", scoreData.clicks);
                        command.Parameters.AddWithValue("@time", scoreData.time);
                        command.Parameters.AddWithValue("@username", scoreData.Username);
                        command.Parameters.AddWithValue("@ApplicationUserId", scoreData.ApplicationUserId);
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

            if (HttpContext.Session.Get("savedScore") != null)
            {
                HttpContext.Session.Remove("savedScore");
            }
            return Ok(new { message = "Score saved successfully" });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id) {

            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.GetUserAsync(User);
                var username = await _userManager.GetUserNameAsync(user);
                Score? score = _dbContext.Scores.FirstOrDefault(s => s.Id == Id);
                if (score != null && score.Username == username)
                {
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
                else
                {
                    return BadRequest("Can only delete your own scores");
                }
            }
            return BadRequest("Must be signed in to delete your scores");

        }
    }
}
