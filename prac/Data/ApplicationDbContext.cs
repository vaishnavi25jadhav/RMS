using Microsoft.EntityFrameworkCore;
using ResTask.Model;

namespace ResTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Order { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<ResTask.Model.Order> Orders { get; set; }
    }
}
