using GestioneTurniAgenti.Shared.Dtos.Turno;
using GestioneTurniAgenti.Shared.SearchParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Client.Services
{
    public class TurniService : ITurniService
    {
        private readonly HttpClient _client;

        public TurniService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<string> CreateTurno(TurnoForCreationDto turnoDto)
        {
            var res = await _client.PostAsJsonAsync("turni", turnoDto);
            if (res.IsSuccessStatusCode)
            {
                return null;
            }
            else
            {
                return await res.Content.ReadAsStringAsync();
            }
        }

        public async Task DeleteTurno(Guid turnoId)
        {
            await _client.DeleteAsync($"turni/{turnoId}");
        }

        public async Task<IEnumerable<TurnoDto>> GetAllTurni(TurniSearchParameters searchParameters)
        {
            string queryString = "?";

            if (!string.IsNullOrWhiteSpace(searchParameters.AgenteNome))
            {
                queryString += $"AgenteNome={searchParameters.AgenteNome}&";
            }

            if (!string.IsNullOrWhiteSpace(searchParameters.AgenteCognome))
            {
                queryString += $"AgenteCognome={searchParameters.AgenteCognome}&";
            }

            if (!string.IsNullOrWhiteSpace(searchParameters.AgenteMatricola))
            {
                queryString += $"AgenteMatricola={searchParameters.AgenteMatricola}&";
            }

            if (searchParameters.RepartoId.HasValue)
            {
                queryString += $"RepartoId={searchParameters.RepartoId}";
            }

            if (searchParameters.EventoId.HasValue)
            {
                queryString += $"EventoId={searchParameters.EventoId}";
            }

            var turni = await _client.GetFromJsonAsync<IEnumerable<TurnoDto>>($"turni/{queryString}");

            return turni;
        }

        public async Task<TurnoDto> GetTurnoById(Guid turnoId)
        {
            var turno = await _client.GetFromJsonAsync<TurnoDto>($"turni/{turnoId}");

            return turno;
        }

        public async Task<string> UpdateTurno(Guid turnoId, TurnoForUpdateDto turnoDto)
        {
            var res = await _client.PutAsJsonAsync($"turni/{turnoId}", turnoDto);
            if (res.IsSuccessStatusCode)
            {
                return null;
            }
            else
            {
                return await res.Content.ReadAsStringAsync();
            }
        }
    }
}