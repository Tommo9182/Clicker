using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClickerWebApp.Model;
using System.Data.SqlClient;

namespace ClickerWebApp.Pages
{
    public class UsersModel : PageModel
    {
        public List<User> users = new List<User>();
		public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.;Initial Catalog=ClickerDB;Integrated Security=True";

                using(SqlConnection connection  = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String getUsersQuery = "SELECT * FROM Users";
                    using(SqlCommand command = new SqlCommand(getUsersQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string username = reader.GetString(1);
                                string password = reader.GetString(2);
                                User user = new User(id, username, password);

                                users.Add(user);
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
