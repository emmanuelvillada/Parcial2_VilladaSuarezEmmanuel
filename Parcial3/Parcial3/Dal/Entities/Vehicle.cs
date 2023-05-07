using System.ComponentModel.DataAnnotations;

namespace Parcial3.Dal.Entities
{
    public class Vehicle: IdEntity
    {
        
        public Service Service { get; set; }

        [Display(Name = "Propietario")]
        public string Owner { get; set; }

        [Display(Name = "Placa")]
        public string NumberPlate { get; set; }

        [Display(Name = "Detalles de vehiculos")]
        public ICollection<VehicleDetail> VehiclesDetails { get; set; }
    }
}
