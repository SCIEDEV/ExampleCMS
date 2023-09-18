using CMS.Models;
using Microsoft.EntityFrameworkCore;

namespace CMS.Data
{
    public class ClassDatabaseContext : DbContext
    {
        public ClassDatabaseContext(DbContextOptions<ClassDatabaseContext> options) : base(options)
        {
        }

        public DbSet<Classes> Classes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classes>().HasData(
                new Classes { ID = 1, period = 1, className = "Physcis" },
                new Classes { ID = 2, period = 2, className = "Literature" }
            );
        }
    }
}