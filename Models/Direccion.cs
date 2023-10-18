using System;
using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_C.Models
{
    public class Direccion
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength =5)]
        public string Calle { get; set; }
        public int Numero { get; set; }
        public int Piso { get; set; }
        public string Departamento { get; set; }

        [Display(Name ="Codigo Postal")]
        public string CodigoPostal { get; set; }

        [Display(Name ="Cliente")]
        public int ClienteId { get; set; } //prop    relacional
        public Cliente Cliente { get; set; } //prop navegacional

    }
}
