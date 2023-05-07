using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace Parcial3.Dal.Entities
{
	public class Vehicle : Entity
	{
		

		[Display(Name = "Servicio")]		
		public Service? Service { get; set; }

		[Display(Name = "Propietario")]
		public string? Owner { get; set; }

		[Display(Name ="Placa")]
		public string? NumberPlate { get; set; }

		public ICollection<VehicleDetail>? VehicleDetails { get; set; }

		

	}
}
