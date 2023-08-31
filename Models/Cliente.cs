namespace Estacionamiento_C.Models
{
    public class Cliente : Persona
    {
        public long CUIT { get; set; }

        public Direccion Direccion { get; set; }                

    }
}
