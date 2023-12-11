using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClickerWebApp.Pages
{
    public class LeaderboardModel : PageModel
    {
        private readonly ILogger<LeaderboardModel> _logger;

        public LeaderboardModel(ILogger<LeaderboardModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}