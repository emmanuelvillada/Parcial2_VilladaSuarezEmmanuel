using System.ComponentModel.DataAnnotations;

namespace Parcial3.Dal.Entities
{
	public class VehicleDetail
	{
		[Key]
		[Required]
		public Guid Id { get; set; }

		[Display(Name = "Vehiculo")]
		public Vehicle VehicleId { get; set; }

		[Display(Name = "Fecha de Creacion")]
		public DateTime CreationDate { get; set; }

		[Display(Name = "Fecha de Entrega")]
		public DateTime DeliveryDate { get; set; }
	}
}
