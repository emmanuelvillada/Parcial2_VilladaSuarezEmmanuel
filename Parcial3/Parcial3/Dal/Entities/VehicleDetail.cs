using System.ComponentModel.DataAnnotations;

namespace Parcial3.Dal.Entities
{
    public class VehicleDetail: IdEntity
    {
        
        public Vehicle Vehicle { get; set; }

        [Display(Name = "Fecha de creacion")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Fecha de entrega")]
        public DateTime DeliveryDate { get; set;}
    }
}
