using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Toolbelt.Blazor;

namespace GestioneTurniAgenti.Client.HttpInterceptor
{
    public class HttpInterceptorService
    {
        private readonly HttpClientInterceptor _interceptor;
        private readonly NavigationManager _navManager;
        private readonly IToastService _toastService;

        public HttpInterceptorService(HttpClientInterceptor interceptor, NavigationManager navManager, IToastService toastService)
        {
            _interceptor = interceptor ?? throw new ArgumentNullException(nameof(interceptor));
            _navManager = navManager ?? throw new ArgumentNullException(nameof(navManager));
            _toastService = toastService ?? throw new ArgumentNullException(nameof(toastService));
        }

        public void RegisterEvent() => _interceptor.AfterSend += HandleResponse;

        public void DisposeEvent() => _interceptor.AfterSend -= HandleResponse;

        private void HandleResponse(object sender, HttpClientInterceptorEventArgs e)
        {
            if (e.Response == null)
            {
                _navManager.NavigateTo("/error");
                throw new HttpResponseException("Server not available.");
            }

            var message = string.Empty;

            if (!e.Response.IsSuccessStatusCode)
            {
                switch (e.Response.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        _navManager.NavigateTo("/404");
                        message = "Risorsa non trovata.";
                        break;

                    case HttpStatusCode.BadRequest:
                        message = "Richiesta invalida. Per favore verifica i dati inseriti.";
                        //message = e.Response.Content.ReadAsStringAsync().Result;
                        _toastService.ShowError(message);
                        break;

                    case HttpStatusCode.Unauthorized:
                        _navManager.NavigateTo("/unauthorized");
                        message = "Accesso non autorizzato.";
                        break;

                    default:
                        _navManager.NavigateTo("/error");
                        message = $"Qualcosa è andato storto. Errore {e.Response.StatusCode}.";
                        break;
                }

                //throw new HttpResponseException(message);
            }
        }
    }
}