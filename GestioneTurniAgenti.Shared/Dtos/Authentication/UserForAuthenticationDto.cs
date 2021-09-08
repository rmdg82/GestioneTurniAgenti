using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Shared.Dtos.Authentication
{
    public class UserForAuthenticationDto
    {
        [Required(ErrorMessage = "Username è un campo obbligatorio")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password è un campo obbligatorio")]
        public string Password { get; set; }
    }
}