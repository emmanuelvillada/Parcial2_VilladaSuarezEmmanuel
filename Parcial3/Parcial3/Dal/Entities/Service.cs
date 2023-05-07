using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Parcial3.Dal.Entities
{
	public class Service: Entity
	{
		

		[Display(Name = "Servicio")]
		public string? Name { get;set; }

		[Display (Name = "Precio")]
		public String? Price { get; set; }

		[Display (Name = "Vehiculos")]
		public ICollection<Vehicle>? Vehicles { get; set; }	
	}
}
