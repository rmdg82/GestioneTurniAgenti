using GestioneTurniAgenti.Shared.Dtos.Eventi;
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
    public class EventiService : IEventiService
    {
        private readonly HttpClient _client;

        public EventiService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task DeleteEvento(Guid eventoId)
        {
            await _client.DeleteAsync($"eventi/{eventoId}");
        }

        public async Task<IEnumerable<EventoDto>> GetAllEventi()
        {
            var eventi = await _client.GetFromJsonAsync<IEnumerable<EventoDto>>("eventi");

            return eventi;
        }

        public async Task<IEnumerable<EventoDto>> GetAllEventi(EventiSearchParameters searchParameters)
        {
            string queryString = "?";

            if (searchParameters != null)
            {
                if (!string.IsNullOrWhiteSpace(searchParameters.Nome))
                {
                    queryString += $"Nome={searchParameters.Nome}&";
                }

                if (!string.IsNullOrWhiteSpace(searchParameters.MatricolaAgente))
                {
                    queryString += $"MatricolaAgente={searchParameters.MatricolaAgente}";
                }
            }

            var eventi = await _client.GetFromJsonAsync<IEnumerable<EventoDto>>($"eventi/{queryString}");

            return eventi;
        }

        public async Task<EventoDto> GetEventoById(Guid eventoId)
        {
            var evento = await _client.GetFromJsonAsync<EventoDto>($"eventi/{eventoId}");

            return evento;
        }

        public async Task<string> CreateEvento(EventoForCreationDto eventoDto)
        {
            var response = await _client.PostAsJsonAsync("eventi", eventoDto);
            if (response.IsSuccessStatusCode)
            {
                return null;
            }
            else
            {
                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> UpdateEvento(Guid eventoId, EventoForUpdateDto eventoDto)
        {
            var response = await _client.PutAsJsonAsync($"eventi/{eventoId}", eventoDto);
            if (response.IsSuccessStatusCode)
            {
                return null;
            }
            else
            {
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}