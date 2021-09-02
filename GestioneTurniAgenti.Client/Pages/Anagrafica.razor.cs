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

namespace GestioneTurniAgenti.Client.Pages
{
    public partial class Anagrafica : IDisposable
    {
        [CascadingParameter]
        public Task<AuthenticationState> AuthState { get; set; }

        [Inject]
        public IAnagraficaService AnagraficaService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        public List<RepartoDto> Reparti { get; set; } = new();

        public AgentiSearchParameters AgentiSearchParameters { get; set; } = new();
        public IEnumerable<AgenteDto> Agenti { get; set; } = null;

        protected override async Task OnInitializedAsync()
        {
            Interceptor.RegisterEvent();
            await GetAllReparti();
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

        private string GetAggiungiTurnoUrl(Guid agenteId)
        {
            return $"/aggiungiTurno/{agenteId}";
        }

        public void Dispose()
        {
            Interceptor.DisposeEvent();
        }
    }
}