using Blazored.Toast.Services;
using GestioneTurniAgenti.Client.HttpInterceptor;
using GestioneTurniAgenti.Client.Services;
using GestioneTurniAgenti.Shared.Dtos.Eventi;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Client.Pages
{
    public partial class UpdateEvento : IDisposable
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
        public Guid EventoId { get; set; }

        public string NomeEvento { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }

        private EventoForUpdateDto _eventoForUpdateDto = new();
        private EditContext _editContext;
        private bool _formInvalid = true;

        protected override async Task OnInitializedAsync()
        {
            _editContext = new EditContext(_eventoForUpdateDto);
            _editContext.OnFieldChanged += HandleFieldChanged;
            Interceptor.RegisterEvent();

            await FetchDataFromEventoId(EventoId);
        }

        public async Task FetchDataFromEventoId(Guid eventoId)
        {
            EventoDto evento = await EventiService.GetEventoById(eventoId);
            _eventoForUpdateDto.Nome = evento.Nome;
            _eventoForUpdateDto.Inizio = evento.Inizio;
            _eventoForUpdateDto.Fine = evento.Fine;

            NomeEvento = evento.Nome;
            DataInizio = evento.Inizio;
            DataFine = evento.Fine;
        }

        private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
        {
            _formInvalid = !_editContext.Validate();
            StateHasChanged();
        }

        private async Task Update()
        {
            var errorMessage = await EventiService.UpdateEvento(EventoId, _eventoForUpdateDto);

            if (errorMessage is null)
            {
                ToastService.ShowSuccess("Evento modificato con successo!");
                NavigationManager.NavigateTo("/eventi");
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
            _editContext = new EditContext(_eventoForUpdateDto);
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