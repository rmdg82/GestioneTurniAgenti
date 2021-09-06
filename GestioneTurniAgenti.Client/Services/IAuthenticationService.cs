using GestioneTurniAgenti.Shared.Dtos.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Client.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponseDto> Login(UserForAuthenticationDto userForAuthenticationDto);

        Task Logout();
    }
}