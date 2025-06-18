using Microsoft.EntityFrameworkCore;
using PIMSys.Models;

namespace PIMSys.Data
{
    public class AppDbContext : DbContext {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) {}
    }
}