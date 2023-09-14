using System.Collections.Generic;

namespace Estacionamiento_C.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }

        public int AnioFabricacion { get; set; }
        public List<Estancia> Estancias { get; set; }

        public string Foto { get; set; }

        public List<ClienteVehiculo> ClientesVehiculos { get; set; }

    }
}
