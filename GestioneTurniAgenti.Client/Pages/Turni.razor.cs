using Blazored.Toast.Services;
using GestioneTurniAgenti.Client.Components;
using GestioneTurniAgenti.Client.HttpInterceptor;
using GestioneTurniAgenti.Client.Services;
using GestioneTurniAgenti.Shared.Dtos.Anagrafica;
using GestioneTurniAgenti.Shared.Dtos.Eventi;
using GestioneTurniAgenti.Shared.Dtos.Turno;
using GestioneTurniAgenti.Shared.SearchParameters;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Client.Pages
{
    public partial class Turni : IDisposable
    {
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

        protected override async Task OnInitializedAsync()
        {
            Interceptor.RegisterEvent();
            await GetAllReparti();
            await GetAllEventi();
        }

        public async Task GetAllReparti()
        {
            Reparti = (await AnagraficaService.GetAllReparti()).ToList();
        }

        public async Task GetAllEventi()
        {
            Eventi = (await EventiService.GetAllEventi()).ToList();
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