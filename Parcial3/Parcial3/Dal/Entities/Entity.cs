using System.ComponentModel.DataAnnotations;

namespace Parcial3.Dal.Entities
{
	public class IdEntity
	{
		[Key]
		[Required]
		public Guid Id { get; set; }
	}
}
