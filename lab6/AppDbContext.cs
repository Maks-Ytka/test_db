using Microsoft.EntityFrameworkCore;
using TaskContentCRUD.Models;

namespace TaskContentCRUD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskContent> TaskContents { get; set; }
    }
}
