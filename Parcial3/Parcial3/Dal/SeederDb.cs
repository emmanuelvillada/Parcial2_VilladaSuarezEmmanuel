using Parcial3.Dal.Entities;
using Parcial3.Enums;
using Parcial3.Helpers;
using System.Diagnostics.Metrics;

namespace Parcial3.Dal
{
	public class SeederDb
	{
		private readonly DatabaseContext _context;
		private readonly IUserHelper _userHelper;

		public SeederDb(DatabaseContext context, IUserHelper userHelper)
		{
			_context = context;
			_userHelper = userHelper;
		}

		public async Task SeederAsync()
		{
			await _context.Database.EnsureCreatedAsync(); // me reemplaza el comando update-database
			await PopulateServicesAsync();
			await PopulateCountriesAsync();
			await PopulateRolesAsync();
			await PopulateUserAsync("Admin", "Role", "admin_role@yopmail.com", "3002323232", "Street Fighter 1", "102030", UserType.Admin);
			await PopulateUserAsync("Client", "Role", "client_role@yopmail.com", "40056566756", "Street Fighter 2", "405060", UserType.Client);

			await _context.SaveChangesAsync();
		}

		private async Task PopulateServicesAsync()
		{
			if (!_context.Services.Any())
			{
				_context.Categories.Add(new Category { Name = "Tecnología", Description = "Elementos tech", CreatedDate = DateTime.Now });
				_context.Categories.Add(new Category { Name = "Implementos de Aseo", Description = "Detergente, jabón, etc.", CreatedDate = DateTime.Now });
				_context.Categories.Add(new Category { Name = "Ropa interior", Description = "Tanguitas, narizonas", CreatedDate = DateTime.Now });
				_context.Categories.Add(new Category { Name = "Gamers", Description = "PS5, XBOX SERIES", CreatedDate = DateTime.Now });
				_context.Categories.Add(new Category { Name = "Mascotas", Description = "Concentrado, jabón para pulgas.", CreatedDate = DateTime.Now });
			}
		}
		private async Task PopulateCountriesAsync()
		{
			if (!_context.Countries.Any())
			{
				_context.Countries.Add(new Country
				{
					CreatedDate = DateTime.Now,
					Name = "Colombia",
					States = new List<State>()
					{
						new State
						{
							CreatedDate = DateTime.Now,
							Name = "Antioquia",
							Cities = new List<City>()
							{
								new City { Name = "Medellín", CreatedDate = DateTime.Now },
								new City { Name = "Envigado", CreatedDate = DateTime.Now },
								new City { Name = "Bello", CreatedDate = DateTime.Now },
								new City { Name = "Itagüí", CreatedDate = DateTime.Now },
								new City { Name = "Barbosa", CreatedDate = DateTime.Now },
								new City { Name = "Copacabana", CreatedDate = DateTime.Now },
								new City { Name = "Girardota", CreatedDate = DateTime.Now },
								new City { Name = "Sabaneta", CreatedDate = DateTime.Now },
							}
						},

						new State
						{
							CreatedDate = DateTime.Now,
							Name = "Cundinamarca",
							Cities = new List<City>()
							{
								new City { Name = "Bogotá", CreatedDate = DateTime.Now },
								new City { Name = "Engativá", CreatedDate = DateTime.Now },
								new City { Name = "Fusagasugá", CreatedDate = DateTime.Now },
								new City { Name = "Villeta", CreatedDate = DateTime.Now },
							}
						}
					}
				});

				_context.Countries.Add(new Country
				{
					CreatedDate = DateTime.Now,
					Name = "Argentina",
					States = new List<State>()
					{
						new State
						{
							CreatedDate = DateTime.Now,
							Name = "Buenos Aires",
							Cities = new List<City>()
							{
								new City { Name = "Alberti", CreatedDate = DateTime.Now },
								new City { Name = "Avellaneda", CreatedDate = DateTime.Now },
								new City { Name = "Bahía Blanca", CreatedDate = DateTime.Now },
								new City { Name = "Ezeiza", CreatedDate = DateTime.Now },
							}
						},

						new State
						{
							Name = "La Pampa",
							Cities = new List<City>()
							{
								new City { Name = "Parera", CreatedDate = DateTime.Now },
								new City { Name = "Santa Isabel", CreatedDate = DateTime.Now },
								new City { Name = "Puelches", CreatedDate = DateTime.Now },
								new City { Name = "La Adela", CreatedDate = DateTime.Now },
							}
						}
					}
				});
			}
		}

		private async Task PopulateRolesAsync()
		{
			await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
			await _userHelper.CheckRoleAsync(UserType.User.ToString());
		}

		private async Task PopulateUserAsync(
			string firstName,
			string lastName,
			string email,
			string phone,
			string address,
			string document,
			UserType userType)
		{
			User user = await _userHelper.GetUserAsync(email);

			if (user == null)
			{
				user = new User
				{
					CreatedDate = DateTime.Now,
					FirstName = firstName,
					LastName = lastName,
					Email = email,
					UserName = email,
					PhoneNumber = phone,
					Address = address,
					Document = document,
					City = _context.Cities.FirstOrDefault(),
					UserType = userType,
				};

				await _userHelper.AddUserAsync(user, "123456");
				await _userHelper.AddUserToRoleAsync(user, userType.ToString());
			}
		}
	}
}
