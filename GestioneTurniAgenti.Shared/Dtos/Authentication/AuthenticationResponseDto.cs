using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Shared.Dtos.Authentication
{
    public class AuthenticationResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public Guid RepartoId { get; set; }
        public string NomeReparto { get; set; }
        public string Token { get; set; }
    }
}