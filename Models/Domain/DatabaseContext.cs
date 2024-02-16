using Microsoft.EntityFrameworkCore;

namespace TechNeuronsProj.Models.Domain
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext>options):base (options)
        {
            
        }
        public DbSet<Task> Task { get; set; }
    }
}
