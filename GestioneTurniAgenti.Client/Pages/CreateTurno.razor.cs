using Blazored.Toast.Services;
using GestioneTurniAgenti.Client.HttpInterceptor;
using GestioneTurniAgenti.Client.Services;
using GestioneTurniAgenti.Shared.Dtos.Anagrafica;
using GestioneTurniAgenti.Shared.Dtos.Eventi;
using GestioneTurniAgenti.Shared.Dtos.Turno;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Client.Pages
{
    public partial class CreateTurno : IDisposable
    {
        [Inject]
        public IAnagraficaService AnagraficaService { get; set; }

        [Inject]
        public IEventiService EventiService { get; set; }

        [Inject]
        public ITurniService TurniService { get; set; }

        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        [Inject]
        public IToastService ToastService { get; set; }

        [Parameter]
        public Guid AgenteId { get; set; }

        public List<EventoDto> Eventi { get; set; } = new();

        public string NomeAgente { get; set; }
        public string CognomeAgente { get; set; }
        public string MatricolaAgente { get; set; }
        public string RepartoAgente { get; set; }

        private TurnoForCreationDto _turno = new();
        private EditContext _editContext;
        private bool _formInvalid = true;

        public async Task GetEventi()
        {
            Eventi = (await EventiService.GetAllEventi()).ToList();
        }

        public async Task FetchDataFromAgenteId(Guid agenteId)
        {
            AgenteDto agente = await AnagraficaService.GetAgenteById(agenteId);
            _turno.AgenteId = agenteId;
            _turno.Data = DateTime.Now;
            NomeAgente = agente.Nome;
            CognomeAgente = agente.Cognome;
            MatricolaAgente = agente.Matricola;
            RepartoAgente = agente.NomeReparto;
        }

        protected override async Task OnInitializedAsync()
        {
            _editContext = new EditContext(_turno);
            _editContext.OnFieldChanged += HandleFieldChanged;
            Interceptor.RegisterEvent();

            await FetchDataFromAgenteId(AgenteId);
            await GetEventi();
        }

        private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
        {
            _formInvalid = !_editContext.Validate();
            StateHasChanged();
        }

        private async Task Create()
        {
            var errorMessage = await TurniService.CreateTurno(_turno);

            if (errorMessage == null)
            {
                ToastService.ShowSuccess("Turno aggiunto con successo!");
            }
            else
            {
                ToastService.ShowWarning(errorMessage);
            }
            _turno = new();
            _editContext.OnValidationStateChanged += ValidationChanged;
            _editContext.NotifyValidationStateChanged();
        }

        private void ValidationChanged(object sender, ValidationStateChangedEventArgs e)
        {
            _formInvalid = true;
            _editContext.OnFieldChanged -= HandleFieldChanged;
            _editContext = new EditContext(_turno);
            _editContext.OnFieldChanged += HandleFieldChanged;
            _editContext.OnValidationStateChanged -= ValidationChanged;
        }

        public void Dispose()
        {
            Interceptor.DisposeEvent();
            _editContext.OnFieldChanged -= HandleFieldChanged;
            _editContext.OnValidationStateChanged -= ValidationChanged;
        }
    }
}