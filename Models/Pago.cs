using System.ComponentModel.DataAnnotations.Schema;

namespace Estacionamiento_C.Models
{
    public class Pago
    {
        public int Id { get; set; }

        
        public int EstanciaId { get; set; }

        public Estancia Estancia { get; set; }
        public decimal Monto { get; set; }
    }
}
