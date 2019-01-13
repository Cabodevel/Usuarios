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
            [Required]
            [EmailAddress]
            public int Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }


    }

}
