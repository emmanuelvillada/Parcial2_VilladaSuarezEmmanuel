using System.ComponentModel.DataAnnotations;

namespace Parcial3.Dal.Entities
{
    public class Vehicle: IdEntity
    {
        
        public Service ServiceService { get; set; }

        [Display(Name = "Propietario")]
        public String Owner { get; set; }

        [Display(Name = "Placa")]
        public String NumberPlate { get; set; }    
    }
}
