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
    }
}
