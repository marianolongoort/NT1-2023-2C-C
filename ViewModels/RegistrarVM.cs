using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Estacionamiento_C.ViewModels
{
    public class RegistrarVM
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo electronico")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "La {0} no es igual")]
        [Display(Name = "Confirmacion")]
        public string ConfirmPassword { get; set; }


    }
}
