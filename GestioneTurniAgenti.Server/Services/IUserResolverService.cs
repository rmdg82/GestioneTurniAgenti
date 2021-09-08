using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Server.Services
{
    public interface IUserResolverService
    {
        string GetUsername();

        string GetRole();
    }
}