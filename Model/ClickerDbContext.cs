using Microsoft.EntityFrameworkCore;

namespace ClickerWebApp.Model
{
    public class ClickerDbContext : DbContext
    {
        public DbSet<Score> Scores { get; set; }

        public ClickerDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
