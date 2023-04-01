using System.Diagnostics.Metrics;
using ConcertApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConcertApp.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options ) : base(options) 
        {
            
        }
        public DbSet<Tickets> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tickets>().HasIndex(t => t.Id).IsUnique();          
        }
    }
}
