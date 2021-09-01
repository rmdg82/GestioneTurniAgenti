using Blazored.Toast.Services;
using GestioneTurniAgenti.Client.Components;
using GestioneTurniAgenti.Client.HttpInterceptor;
using GestioneTurniAgenti.Client.Services;
using GestioneTurniAgenti.Shared.Dtos.Eventi;
using GestioneTurniAgenti.Shared.SearchParameters;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Client.Pages
{
    public partial class Eventi : IDisposable
    {
        [Inject]
        public IAnagraficaService AnagraficaService { get; set; }

        [Inject]
        public IEventiService EventiService { get; set; }

        [Inject]
        public IToastService ToastService { get; set; }

        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        public EventiSearchParameters EventiSearchParameters { get; set; } = new();
        public IEnumerable<EventoDto> EventiReturned { get; set; } = null;

        private ConfirmationDeleteEvento _confirmation;
        private Guid _eventoToDeleteId;

        protected override void OnInitialized()
        {
            Interceptor.RegisterEvent();
        }

        public async Task GetEventi()
        {
            EventiReturned = await EventiService.GetAllEventi(EventiSearchParameters);
            StateHasChanged();
        }

        public void CallConfirmationModal(EventoDto eventoToDeleteDto)
        {
            _confirmation.Show(eventoToDeleteDto);
            _eventoToDeleteId = eventoToDeleteDto.Id;
        }

        public async Task DeleteEvento()
        {
            _confirmation.Hide();

            var errorMessage = await EventiService.DeleteEvento(_eventoToDeleteId);
            if (errorMessage is null)
            {
                ToastService.ShowSuccess("Evento eliminato con successo!");
            }
            else
            {
                ToastService.ShowWarning(errorMessage);
            }

            await GetEventi();
        }

        public void Dispose()
        {
            Interceptor.DisposeEvent();
        }
    }
}