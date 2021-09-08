using Blazored.Toast.Services;
using GestioneTurniAgenti.Client.Components;
using GestioneTurniAgenti.Client.HttpInterceptor;
using GestioneTurniAgenti.Client.Services;
using GestioneTurniAgenti.Shared.Dtos.Anagrafica;
using GestioneTurniAgenti.Shared.Dtos.Eventi;
using GestioneTurniAgenti.Shared.Dtos.Turno;
using GestioneTurniAgenti.Shared.SearchParameters;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using GestioneTurniAgenti.Client.Authentication;

namespace GestioneTurniAgenti.Client.Pages
{
    public partial class Turni : IDisposable
    {
        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationStateTask { get; set; }

        [Inject]
        public IAnagraficaService AnagraficaService { get; set; }

        [Inject]
        public IEventiService EventiService { get; set; }

        [Inject]
        public ITurniService TurniService { get; set; }

        [Inject]
        public IToastService ToastService { get; set; }

        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        private ConfirmationDeleteTurno _confirmation;
        private Guid _turnoToDeleteId;

        public List<RepartoDto> Reparti { get; set; } = new();
        public List<EventoDto> Eventi { get; set; } = new();

        public TurniSearchParameters TurniSearchParameters { get; set; } = new();
        public IEnumerable<TurnoDto> TurniReturned { get; set; } = null;

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

            await GetAllEventi();
            StateHasChanged();
        }

        public async Task GetAllReparti()
        {
            Reparti = (await AnagraficaService.GetAllReparti()).ToList();
        }

        public async Task GetOwnReparto(string username)
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
            TurniSearchParameters.RepartoId = ownRepartoGuid;

            Reparti.Add(reparto);
        }

        public async Task GetAllEventi()
        {
            Eventi = (await EventiService.GetAllEventi(null)).ToList();
        }

        public async Task GetTurni()
        {
            TurniReturned = await TurniService.GetAllTurni(TurniSearchParameters);
            StateHasChanged();
        }

        public void CallConfirmationModal(TurnoDto turnoToDeleteDto)
        {
            _confirmation.Show(turnoToDeleteDto);
            _turnoToDeleteId = turnoToDeleteDto.Id;
        }

        public async Task DeleteTurno()
        {
            _confirmation.Hide();
            await TurniService.DeleteTurno(_turnoToDeleteId);
            ToastService.ShowSuccess("Turno eliminato con successo!");
            await GetTurni();
        }

        public void Dispose()
        {
            Interceptor.DisposeEvent();
        }
    }
}