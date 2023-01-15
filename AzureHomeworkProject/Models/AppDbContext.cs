using Microsoft.EntityFrameworkCore;

namespace AzureHomeworkProject.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<CommentModel> Comments { get; set; }
    }
}
