using System.ComponentModel.DataAnnotations;

namespace Parcial3.Dal.Entities
{
    public class Service: IdEntity
    {
        [Display(Name = "Nombre del servicio")]
        public String Name { get; set; }

        [Display(Name = "Precio")]
        public String Price { get; set; }


    }
}
