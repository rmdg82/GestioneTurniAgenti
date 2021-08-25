using GestioneTurniAgenti.Shared.Dtos.Anagrafica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Client.Services
{
    public class AnagraficaService : IAnagraficaService
    {
        private readonly HttpClient _client;

        public AnagraficaService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<AgenteDto> GetAgenteById(Guid agenteId)
        {
            var agente = await _client.GetFromJsonAsync<AgenteDto>($"anagrafica/agenti/{agenteId}");

            return agente;
        }

        public async Task<IEnumerable<AgenteDto>> GetAllAgenti()
        {
            var agenti = await _client.GetFromJsonAsync<IEnumerable<AgenteDto>>("anagrafica/agenti");

            return agenti;
        }

        public async Task<IEnumerable<RepartoDto>> GetAllReparti()
        {
            var reparti = await _client.GetFromJsonAsync<IEnumerable<RepartoDto>>("anagrafica/reparti");

            return reparti;
        }

        public async Task<RepartoDto> GetRepartoById(Guid repartoId)
        {
            var reparto = await _client.GetFromJsonAsync<RepartoDto>($"anagrafica/reparti/{repartoId}");

            return reparto;
        }
    }
}