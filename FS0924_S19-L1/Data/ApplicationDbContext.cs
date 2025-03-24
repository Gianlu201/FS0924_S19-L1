using FS0924_S19_L1.Models;
using Microsoft.EntityFrameworkCore;

namespace FS0924_S19_L1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
