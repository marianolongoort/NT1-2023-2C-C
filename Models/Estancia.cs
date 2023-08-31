using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Estacionamiento_C.Models
{
    public class Estancia
    {
        public int Id { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public Cliente Cliente { get; set; }
        public decimal Monto { get; set; }
        public DateTime Inicio{ get; set; }
        public DateTime Fin { get; set; }
        public string Detalle { get; } //Construir detalle - propiedad calculada o computada

        public Page Pago { get; set; }

    }
}
