using GestioneTurniAgenti.Client.Services;
using GestioneTurniAgenti.Shared.Dtos.Anagrafica;
using GestioneTurniAgenti.Shared.SearchParameters;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Client.Pages
{
    public partial class Anagrafica
    {
        [Inject]
        public IAnagraficaService AnagraficaService { get; set; }

        public List<RepartoDto> Reparti { get; set; } = new();

        public AgentiSearchParameters AgentiSearchParameters { get; set; } = new();
        public IEnumerable<AgenteDto> Agenti { get; set; } = null;

        protected override async Task OnInitializedAsync()
        {
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
    }
}