using Estacionamiento_C.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_C.Models
{
    public class Cliente : Persona
    {
        
        [Required(ErrorMessage = ErrorMessages._reqMsg)]
        public long CUIT { get; set; }

        
        public Direccion Direccion { get; set; }

        public List<ClienteVehiculo> ClientesVehiculos { get; set; }

        public List<Estancia> Estancias { get; set; }

    }
}
