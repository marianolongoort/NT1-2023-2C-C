namespace Estacionamiento_C.Models
{
    public class Telefono
    {
        public int Id { get; set; }
        public CodigoDeArea CodArea { get; set; }
        public int Numero { get; set; }

        public bool Principal { get; set; }
        public TipoTelefono Tipo { get; set; }
        public Persona Persona { get; set; }


    }
}
