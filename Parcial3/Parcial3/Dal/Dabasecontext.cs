
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Parcial3.Dal.Entities;

namespace Parcial3.Dal
{
 
		public class DatabaseContext : IdentityDbContext<User>
		{
			public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
			{

			}

			//public DbSet<Country> Countries { get; set; }


			protected override void OnModelCreating(ModelBuilder modelBuilder)
			{
				base.OnModelCreating(modelBuilder);
				//modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
				//modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
				//modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique(); // índices compuestos
				//modelBuilder.Entity<City>().HasIndex("Name", "StateId").IsUnique(); // índices compuestos
			}
		}
	


}
