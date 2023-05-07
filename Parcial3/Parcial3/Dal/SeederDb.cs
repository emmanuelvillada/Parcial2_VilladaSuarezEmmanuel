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
			//await PopulateVehiclesAsync();
			//await PopulateVehiclesDetailAsync();
			await PopulateUserAsync("Admin", "Role", "admin_role@yopmail.com", "3002323232", "Street Fighter 1", "102030", UserType.Admin);
			await PopulateUserAsync("Client", "Role", "client_role@yopmail.com", "40056566756", "Street Fighter 2", "405060", UserType.Client);

			await _context.SaveChangesAsync();
		}



		//private async Task PopulateServicesAsync()
		//{
		//	if (!_context.Services.Any())
		//	{
		//		_context.Services.Add(new Service { Name = "Lavada simple", Price = "$250000" });
		//		_context.Services.Add(new Service { Name = "Lavada + Polishada", Price = "$50000" });
		//		_context.Services.Add(new Service { Name = "Lavada + aspirada de la cojineria", Price = "$30000" });
		//		_context.Services.Add(new Service { Name = "Lavada Full", Price = "$65000" });
		//		_context.Services.Add(new Service { Name = "Lavada en seco del motor", Price = "$80000" });
		//		_context.Services.Add(new Service { Name = "Lavada chasis", Price = "$90000" });

		//	}
		//}
		//private async Task PopulateVehiclesAsync()
		//{
		//	if (!_context.Vehicles.Any())
		//	{
		//		_context.Vehicles.Add(new Vehicle { Owner = "Emmanuel Villada", NumberPlate = "GFE 063" });
		//	}
		//}

		//private async Task PopulateVehiclesDetailAsync()
		//{
		//	if (!_context.VehiclesDetails.Any())
		//	{
		//		_context.VehiclesDetails.Add(new VehicleDetail { CreationDate = DateTime.Now, });
		//	}
		//}

		private async Task PopulateServicesAsync()
		{
			if (!_context.Services.Any())
			{
				_context.Services.Add(new Service
				{
					Price = "$25.000",
					Name = "Lavada simple",
					Vehicles = new List<Vehicle>()
							{
								new Vehicle
								{
									Owner = "Emmanuel Villada Suárez",
									NumberPlate = "GFE 023",
									VehiclesDetails = new List<VehicleDetail>()
									{
										new VehicleDetail { CreationDate = DateTime.Now, DeliveryDate = DateTime.Now }

									}
								},

								new Vehicle
								{
									Owner = "Elon Musk",
									NumberPlate = "TFT 568",
									VehiclesDetails = new List<VehicleDetail>()
									{
										new VehicleDetail { CreationDate = DateTime.Now, DeliveryDate = DateTime.Now }

									}
								}
							}
				});
					_context.Services.Add(new Service
					{
						Price = "$50.000",
						Name = "Lavada + polishada",
						Vehicles = new List<Vehicle>()
							{
								new Vehicle
								{
									Owner = "Carlos",
									NumberPlate = "JKL 789",
									VehiclesDetails = new List<VehicleDetail>()
									{
										new VehicleDetail { CreationDate = DateTime.Now, DeliveryDate = DateTime.Now }

									}
								},
							}
					});
                _context.Services.Add(new Service
                {
                    Price = "$30.000",
                    Name = "Lavada + aspirada de cojineria",
                    Vehicles = new List<Vehicle>()
                            {
                                new Vehicle
                                {
                                    Owner = "Carlos",
                                    NumberPlate = "JKL 789",
                                    VehiclesDetails = new List<VehicleDetail>()
                                    {
                                        new VehicleDetail { CreationDate = DateTime.Now, DeliveryDate = DateTime.Now }

                                    }
                                },
                            }
                });
                _context.Services.Add(new Service
                {
                    Price = "$30.000",
                    Name = "Lavada Full",
                    Vehicles = new List<Vehicle>()
                            {
                                new Vehicle
                                {
                                    Owner = "Sebastian",
                                    NumberPlate = "MNB 789",
                                    VehiclesDetails = new List<VehicleDetail>()
                                    {
                                        new VehicleDetail { CreationDate = DateTime.Now, DeliveryDate = DateTime.Now }

                                    }
                                },
                            }
                });
                _context.Services.Add(new Service
                {
                    Price = "$80.000",
                    Name = "Lavada en seco del motor",
                    Vehicles = new List<Vehicle>()
                            {
                                new Vehicle
                                {
                                    Owner = "Sebastian",
                                    NumberPlate = "MNB 789",
                                    VehiclesDetails = new List<VehicleDetail>()
                                    {
                                        new VehicleDetail { CreationDate = DateTime.Now, DeliveryDate = DateTime.Now }

                                    }
                                },
                            }
                });
                _context.Services.Add(new Service
                {
                    Price = "$90.000",
                    Name = "Lavada chasis",
                    Vehicles = new List<Vehicle>()
                            {
                                new Vehicle
                                {
                                    Owner = "Sebastian",
                                    NumberPlate = "MNB 789",
                                    VehiclesDetails = new List<VehicleDetail>()
                                    {
                                        new VehicleDetail { CreationDate = DateTime.Now, DeliveryDate = DateTime.Now }

                                    }
                                },
                            }
                });

            }
			}
		



		private async Task PopulateRolesAsync()
		{
			await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
			await _userHelper.CheckRoleAsync(UserType.Client.ToString());
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
					Vehicle = _context.Vehicles.FirstOrDefault(),
					UserType = userType,
				};

				await _userHelper.AddUserAsync(user, "123456");
				await _userHelper.AddUserToRoleAsync(user, userType.ToString());
			}
		}
	}
}
