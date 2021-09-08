using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazored.Toast.Services;
using GestioneTurniAgenti.Client.AuthProviders;
using GestioneTurniAgenti.Client.Services;
using GestioneTurniAgenti.Shared.SearchParameters;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace GestioneTurniAgenti.Client.Shared
{
    public partial class NavBar
    {
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; }

        [Inject]
        public IAnagraficaService AnagraficaService { get; set; }

        public string Reparto { get; set; } = null;
        public string Username { get; set; } = null;
        public string Role { get; set; } = null;

        protected override async Task OnParametersSetAsync()
        {
            var authState = await AuthenticationStateTask;
            if (authState.User.Identity.IsAuthenticated)
            {
                var username = authState.User.Identity.Name;
                Username = username;
                var roleClaim = authState.User.Claims.FirstOrDefault(c => c.Type.Contains("role"));
                Role = roleClaim.Value;
                var repartoId = (await AnagraficaService.GetAllAgenti(new AgentiSearchParameters { Matricola = Username })).FirstOrDefault().RepartoId;
                Reparto = (await AnagraficaService.GetRepartoById(repartoId)).Nome;
            }
        }
    }
}