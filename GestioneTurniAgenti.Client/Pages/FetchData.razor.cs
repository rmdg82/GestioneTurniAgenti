using GestioneTurniAgenti.Client.Services;
using GestioneTurniAgenti.Shared.Dtos.Anagrafica;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Client.Pages
{
    public partial class FetchData
    {
        private IEnumerable<AgenteDto> agenti;

        [Inject]
        public IAnagraficaService AnagraficaService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            agenti = await AnagraficaService.GetAllAgenti();
        }
    }
}