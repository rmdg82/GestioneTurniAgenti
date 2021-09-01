using Blazored.Toast.Services;
using GestioneTurniAgenti.Client.HttpInterceptor;
using GestioneTurniAgenti.Client.Services;
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
    public partial class UpdateTurno : IDisposable
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

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public Guid TurnoId { get; set; }

        public List<EventoDto> Eventi { get; set; } = new();

        public string NomeAgente { get; set; }
        public string CognomeAgente { get; set; }
        public string MatricolaAgente { get; set; }
        public string RepartoAgente { get; set; }

        private TurnoForUpdateDto _turnoForUpdateDto = new();
        private EditContext _editContext;
        private bool _formInvalid = true;

        protected override async Task OnInitializedAsync()
        {
            _editContext = new EditContext(_turnoForUpdateDto);
            _editContext.OnFieldChanged += HandleFieldChanged;
            Interceptor.RegisterEvent();

            await GetEventi();
            await FetchDataFromTurnoId(TurnoId);
        }

        public async Task GetEventi()
        {
            Eventi = (await EventiService.GetAllEventi(null)).ToList();
        }

        public async Task FetchDataFromTurnoId(Guid turnoId)
        {
            TurnoDto turno = await TurniService.GetTurnoById(turnoId);
            _turnoForUpdateDto.AgenteId = turno.AgenteId;
            _turnoForUpdateDto.EventoId = turno.EventoId;
            _turnoForUpdateDto.Data = turno.Data;
            _turnoForUpdateDto.Note = turno.Note;

            NomeAgente = turno.AgenteNome;
            CognomeAgente = turno.AgenteCognome;
            MatricolaAgente = turno.AgenteMatricola;
            RepartoAgente = turno.AgenteRepartoNome;
        }

        private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
        {
            _formInvalid = !_editContext.Validate();
            StateHasChanged();
        }

        private async Task Update()
        {
            var errorMessage = await TurniService.UpdateTurno(TurnoId, _turnoForUpdateDto);

            if (errorMessage is null)
            {
                ToastService.ShowSuccess("Turno modificato con successo!");
                NavigationManager.NavigateTo("/turni");
            }
            else
            {
                ToastService.ShowWarning(errorMessage);

                _editContext.OnValidationStateChanged += ValidationChanged;
                _editContext.NotifyValidationStateChanged();
            }
        }

        private void ValidationChanged(object sender, ValidationStateChangedEventArgs e)
        {
            _formInvalid = true;
            _editContext.OnFieldChanged -= HandleFieldChanged;
            _editContext = new EditContext(_turnoForUpdateDto);
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