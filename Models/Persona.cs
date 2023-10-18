using Estacionamiento_C.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_C.Models
{
    public class Persona : IdentityUser<int>
    {
        
        //public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages._reqMsg)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = ErrorMessages._reqStrMinMax)]
        public string Nombre { get; set; } = "N/D";

        [Required(ErrorMessage = ErrorMessages._reqMsg)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = ErrorMessages._reqStrMinMax)]
        public string Apellido { get; set; }

        [Display(Name ="Documento")]
        [Range(1000000,99999999,ErrorMessage = ErrorMessages._reqRange)]
        public int DNI { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = ErrorMessages._reqMsg)]
        [Display(Name ="Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }



        [Required]
        [EmailAddress]
        [Display(Name = "Correo electronico")]
        public override string Email
        {
            get { return base.Email; }
            set { base.Email = value; }
        }

        public List<Telefono> Telefonos { get; set; }
        public string Foto { get; set; } = "default.jpg";

        public string NombreCompleto { get {
                return $"{Apellido}, {Nombre}";             
        } }

    }
}
