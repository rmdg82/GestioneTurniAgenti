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
using Microsoft.AspNetCore.Http;

namespace GestioneTurniAgenti.Client.Shared
{
    public partial class NavBar
    {
        //[Inject]
        //private IHttpContextAccessor HttpContextAccessor { get; set; }
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; }

        [Inject]
        public ILocalStorageService LocalStorageService { get; set; }

        [Inject]
        public IToastService ToastService { get; set; }

        public string Reparto { get; set; } = null;
        public string Username { get; set; } = null;

        protected override async Task OnInitializedAsync()
        {
            Reparto = LocalStorageService.GetItemAsStringAsync("nomeReparto").Result;

            var authState = await AuthenticationStateTask;
            if (authState.User.Identity.IsAuthenticated)
            {
                var username = authState.User.Identity.Name;
                Username = username;
            }
        }
    }
}