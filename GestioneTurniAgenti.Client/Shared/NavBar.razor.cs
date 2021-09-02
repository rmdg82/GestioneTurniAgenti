using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GestioneTurniAgenti.Client.AuthProviders;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace GestioneTurniAgenti.Client.Shared
{
    public partial class NavBar
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        public string LoggedUser { get; set; } = "Nessun utente";

        protected override async Task OnInitializedAsync()
        {
            var authstate = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authstate.User;

            if (!user.Identity.IsAuthenticated)
            {
                LoggedUser = "Non autenticato";
            }
            else
            {
                LoggedUser = user.Identity.Name;
            }
        }
    }
}