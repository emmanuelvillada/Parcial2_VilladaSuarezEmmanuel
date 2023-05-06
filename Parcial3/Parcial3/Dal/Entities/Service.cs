using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Parcial3.Dal.Entities
{
	public class Service
	{
		[Key]
		[Required]
		public Guid Id { get; set; }

		[Display(Name = "Servicio")]
		[Required(ErrorMessage = "El campo {0} es oblilgatorio.")]
		public string Name { get;set; }

		[Display (Name = "Precio")]
		[Required(ErrorMessage = "El campo {0} es oblilgatorio.")]
		public decimal Price { get; set; }
	}
}
