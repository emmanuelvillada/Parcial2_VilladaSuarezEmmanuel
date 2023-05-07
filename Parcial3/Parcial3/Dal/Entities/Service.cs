using System.ComponentModel.DataAnnotations;

namespace Parcial3.Dal.Entities
{
    public class Service: IdEntity
    {
        [Display(Name = "Nombre del servicio")]
        public string Name { get; set; }

        [Display(Name = "Precio")]
        public string Price { get; set; }

        [Display(Name = "Vehiculos")]
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
