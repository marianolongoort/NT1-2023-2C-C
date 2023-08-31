namespace Estacionamiento_C.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public Estancia Estancia { get; set; }
        public decimal Monto { get; set; }
    }
}
