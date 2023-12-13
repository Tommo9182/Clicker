using ClickerWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using static System.Formats.Asn1.AsnWriter;

namespace ClickerWebApp.Pages
{
    public class PlayModel : PageModel
    {
        public Score score = new Score();

        public void OnGet()
        {
        }

    }
}
