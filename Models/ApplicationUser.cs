using Microsoft.AspNetCore.Identity;

namespace Clicker.Models
{
	public class ApplicationUser : IdentityUser
	{
		public ICollection<Score> Scores { get; set; }
	}
}
