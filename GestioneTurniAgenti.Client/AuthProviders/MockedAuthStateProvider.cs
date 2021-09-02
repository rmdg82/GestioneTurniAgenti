using Blazored.SessionStorage;
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
    public class MockedAuthStateProvider : AuthenticationStateProvider
    {
        private readonly Roles _selectedRole = Roles.SuperAdmin;

        public static async Task<AuthenticationState> GetAuthenticationStateAsync(Roles role)
        {
            var claims = new List<Claim>();
            ClaimsIdentity identity = new();

            switch (role)
            {
                case Roles.NotAutorized:
                    break;

                case Roles.Admin:
                    claims.Add(new Claim(ClaimTypes.Name, UserNames.Admin));
                    claims.Add(new Claim(ClaimTypes.Role, RoleNames.Admin));
                    identity = new ClaimsIdentity(claims, "MokedAuth");
                    break;

                case Roles.SuperAdmin:
                    claims.Add(new Claim(ClaimTypes.Name, UserNames.SuperAdmin));
                    claims.Add(new Claim(ClaimTypes.Role, RoleNames.SuperAdmin));
                    identity = new ClaimsIdentity(claims, "MokedAuth");
                    break;

                default:
                    break;
            }

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var result = await GetAuthenticationStateAsync(_selectedRole);
            return result;
        }
    }
}