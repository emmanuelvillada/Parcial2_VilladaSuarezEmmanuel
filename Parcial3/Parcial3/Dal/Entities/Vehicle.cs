using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Parcial3.Dal.Entities
{
	public class Vehicle
	{
		[Key]
		[Required]
		public Guid Id { get; set; }

		[Display(Name = "Servicio")]
		public Service ServiceId { get; set; }

		[Display(Name = "Propietario")]
		public string? Owner { get; set; }

		[Display(Name ="Placa")]
		public string? NumberPlate { get; set; }

	}
}
