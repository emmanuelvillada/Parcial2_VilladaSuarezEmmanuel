using System.ComponentModel.DataAnnotations;

namespace ConcertApp.DAL.Entities
{
    public class Tickets
    {
        [Key]
        [Required]
        
        public Guid Id { get; set; }

        [Display (Name = "Fecha de uso")]
        public DateTime UsedDate { get; set; }

        [Display (Name = "Estado de la boleta")]
        [Required (ErrorMessage = "el campo {0} es requerido.")]
        public Boolean IsUsed { get; set;}

        [Display (Name = "Locacion")]
        public string EntranceGate { get; set; }
    }
}
