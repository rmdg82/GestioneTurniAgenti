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
    public partial class CreateEvento : IDisposable
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

        private EventoForCreationDto _eventoForCreationDto = new() { Inizio = DateTime.Now, Fine = DateTime.Now };
        private EditContext _editContext;
        private bool _formInvalid = true;

        protected override void OnInitialized()
        {
            _editContext = new EditContext(_eventoForCreationDto);
            _editContext.OnFieldChanged += HandleFieldChanged;
            Interceptor.RegisterEvent();
        }

        private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
        {
            _formInvalid = !_editContext.Validate();
            StateHasChanged();
        }

        private async Task Create()
        {
            var errorMessage = await EventiService.CreateEvento(_eventoForCreationDto);

            if (errorMessage is null)
            {
                ToastService.ShowSuccess("evento aggiunto con successo!");
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
            _editContext = new EditContext(_eventoForCreationDto);
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