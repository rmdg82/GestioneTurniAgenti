using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Server.Services
{
    public interface IAuthenticationService
    {
        Task<string> GetToken(IdentityUser user);
    }
}