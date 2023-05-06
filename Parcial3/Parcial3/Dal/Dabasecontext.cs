
using System.Diagnostics.Metrics;
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

		public DbSet<Service> Services { get; set; }
		public DbSet<Vehicle> Vehicles { get; set; }
		public DbSet<VehicleDetail> VehiclesDetails { get; set; }
		


		protected override void OnModelCreating(ModelBuilder modelBuilder)
			{
				base.OnModelCreating(modelBuilder);
				modelBuilder.Entity<Service>().HasIndex(s => s.Name).IsUnique();
				 modelBuilder.Entity<Vehicle>().HasIndex("Name", "ServiceId").IsUnique(); 
				modelBuilder.Entity<VehicleDetail>().HasIndex("Name", "VehicleId").IsUnique();
				
			}
		}
	


}
