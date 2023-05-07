using System.ComponentModel.DataAnnotations;

namespace Parcial3.Dal.Entities
{
	public class Entity
	{
		[Key]
		[Required]
		public Guid Id { get; set; }
	}
}
