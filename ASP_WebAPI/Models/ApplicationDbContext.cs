using Microsoft.EntityFrameworkCore;

namespace ASP_WebAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<People> Peoples { get; set; }
    }
}
