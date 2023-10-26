using System.ComponentModel.DataAnnotations;

namespace Estacionamiento_C.ViewModels
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public bool Recordarme { get; set; } = false;
    }
}