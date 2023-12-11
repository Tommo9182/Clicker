using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace ClickerWebApp.Model
{

    public class User
    {
        public User(int id, string name, string pass)
        {
            Id = id;
            Username = name;
            Password = pass;
        }

        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
