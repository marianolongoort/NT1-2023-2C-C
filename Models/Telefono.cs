using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_C.Models
{
    public class Telefono
    {
        public int Id { get; set; }
        [Display(Name ="Codigo de Area")]
        public CodigoDeAreaEnum CodArea { get; set; }
        public int Numero { get; set; }

        public bool Principal { get; set; }
        public TipoTelefonoEnum Tipo { get; set; }

        public int PersonaId { get; set; }  //prop relacional
        public Persona Persona { get; set; } //prop  nav


    }
}
