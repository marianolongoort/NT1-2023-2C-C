using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_C.Models
{
    public class ClienteVehiculo
    {
        [Key]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [Key]
        [Display(Name = "Vehiculo")]
        public int VehiculoId { get; set; }

        public Cliente Cliente { get; set; }
        
        public Vehiculo Vehiculo { get; set; }

    }
}