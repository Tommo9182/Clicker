using Microsoft.EntityFrameworkCore;

namespace ClickerWebApp.Model
{
    public class ClickerDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public ClickerDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
