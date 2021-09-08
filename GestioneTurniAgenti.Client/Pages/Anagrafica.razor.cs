using GestioneTurniAgenti.Client.HttpInterceptor;
using GestioneTurniAgenti.Client.Services;
using GestioneTurniAgenti.Shared.Dtos.Anagrafica;
using GestioneTurniAgenti.Shared.SearchParameters;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using GestioneTurniAgenti.Client.Authentication;

namespace GestioneTurniAgenti.Client.Pages
{
    public partial class Anagrafica : IDisposable
    {
        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationStateTask { get; set; }

        [Inject]
        public IAnagraficaService AnagraficaService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        public List<RepartoDto> Reparti { get; set; } = new();

        public AgentiSearchParameters AgentiSearchParameters { get; set; } = new();
        public IEnumerable<AgenteDto> Agenti { get; set; } = null;

        private bool _isSuperAdmin;

        protected override async Task OnInitializedAsync()
        {
            Interceptor.RegisterEvent();
            var authState = await AuthenticationStateTask;
            string username = null;
            if (authState.User.Identity.IsAuthenticated)
            {
                username = authState.User.Identity.Name;
                var roleClaim = authState.User.Claims.FirstOrDefault(c => c.Type.Contains("role"));
                _isSuperAdmin = roleClaim.Value == RoleNames.SuperAdmin;
            }

            if (_isSuperAdmin)
            {
                await GetAllReparti();
            }
            else
            {
                await GetOwnReparto(username);
            }
        }

        private async Task GetOwnReparto(string username)
        {
            if (username is null)
            {
                throw new ArgumentNullException(nameof(username));
            }

            var ownRepartoGuid =
                (await AnagraficaService.GetAllAgenti(new AgentiSearchParameters { Matricola = username }))
                .SingleOrDefault()
                .RepartoId;
            var reparto = await AnagraficaService.GetRepartoById(ownRepartoGuid);
            AgentiSearchParameters.RepartoId = ownRepartoGuid;

            Reparti.Add(reparto);
        }

        public async Task GetAllReparti()
        {
            Reparti = (await AnagraficaService.GetAllReparti()).ToList();
        }

        public async Task GetAgenti()
        {
            Agenti = await AnagraficaService.GetAllAgenti(AgentiSearchParameters);
            StateHasChanged();
        }

        public void Dispose()
        {
            Interceptor.DisposeEvent();
        }
    }
}