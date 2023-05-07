using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Parcial3.Enums;

namespace Parcial3.Models
{
    public class VehicleServiceModel
    {
        public Guid Id { get; set; }
        
        [Display(Name = "Propietario")]
        public string Owner { get; set; }

        [Display(Name = "Placa")]
        public string NumberPlate { get; set; }

        public Guid ServiceId { get; set; }

        public IEnumerable<SelectListItem> Services { get; set; }

        [Display(Name = "Tipo de usuario")]
        public UserType UserType { get; set; }

        public VehicleServiceModel() { }

    }
}
