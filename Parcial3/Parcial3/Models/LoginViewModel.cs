using System.ComponentModel.DataAnnotations;

namespace Parcial3.Models
{
	public class LoginViewModel
	{
		[Display(Name = "Email")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		[EmailAddress(ErrorMessage = "Debes ingresar un correo válido.")] //Este dataAnnotation me valida que se digite un correo válido por la UI
		public string Username { get; set; }

		[Display(Name = "Contraseña")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		[MinLength(6, ErrorMessage = "El campo {0} debe tener al menos {1} carácteres.")]
		[DataType(DataType.Password)] // Con este decorador, me pinta los puntos cuando digite el password
		public string Password { get; set; }

		[Display(Name = "Recordarme en este navegador")]
		public bool RememberMe { get; set; }
	}
}
