using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Usuarios.Models
{
    public class LoginViewModel
    {
        [BindProperty]
        public InputModel Input { get; set;}
        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage="Campo requerido")]
            [EmailAddress(ErrorMessage ="Email inválido")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "El número de {0} debe ser al menos {2}.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }


    }

}
