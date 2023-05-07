using System.ComponentModel.DataAnnotations;

namespace Parcial3.Dal.Entities
{
	public class VehicleDetail: Entity
	{
		

		[Display(Name = "Vehiculo")]
		public Vehicle? Vehicle { get; set; }

		[Display(Name = "Fecha de Creacion")]
		public DateTime CreationDate { get; set; }

		[Display(Name = "Fecha de Entrega")]
		public DateTime DeliveryDate { get; set; }
	}
}
