using GestioneTurniAgenti.Client.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Client.AuthProviders
{
    public class MockAuthStateProvider : AuthenticationStateProvider
    {
        public static async Task<AuthenticationState> GetAuthenticationStateAsync(Roles role)
        {
            var claims = new List<Claim>();
            ClaimsIdentity identity = new();

            switch (role)
            {
                case Roles.NotAutorized:
                    break;

                case Roles.Admin:
                    claims.Add(new Claim(ClaimTypes.Name, User.Admin));
                    claims.Add(new Claim(ClaimTypes.Role, Role.Admin));
                    identity = new ClaimsIdentity(claims, "MokedAuth");
                    break;

                case Roles.SuperAdmin:
                    claims.Add(new Claim(ClaimTypes.Name, User.SuperAdmin));
                    claims.Add(new Claim(ClaimTypes.Role, Role.SuperAdmin));
                    identity = new ClaimsIdentity(claims, "MokedAuth");
                    break;

                default:
                    break;
            }

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //await Task.Delay(1500);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,"Pippo"),
                new Claim(ClaimTypes.Role,"Administrator"),
            };

            var identity = new ClaimsIdentity(claims, "testAuthType");

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
        }
    }
}