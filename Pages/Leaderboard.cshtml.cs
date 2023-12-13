using ClickerWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace ClickerWebApp.Pages
{
    public class LeaderboardModel : PageModel
    {
        public List<Score> scores = new List<Score>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.;Initial Catalog=ClickerDB;Integrated Security=True;TrustServerCertificate=True;";
                
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
                                Score score = new Score();
                                score.Id = reader.GetInt32(0);
                                score.clicks = reader.GetInt32(1);
                                score.time = reader.GetInt32(2);
                                score.name = reader.GetString(3);
                                score.clicksPerMinute = 60 / reader.GetInt32(2) * reader.GetInt32(1);
                                scores.Add(score);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }
}