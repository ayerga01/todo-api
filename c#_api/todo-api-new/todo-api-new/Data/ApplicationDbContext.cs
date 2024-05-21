using Microsoft.EntityFrameworkCore;
using todo_api_new.Models.config;

namespace todo_api_new.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("DbConnectionString",
                new MySqlServerVersion(new Version(8, 0, 21)));
        }
    }
}
