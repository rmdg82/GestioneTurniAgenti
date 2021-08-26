using GestioneTurniAgenti.Shared.Dtos.Turno;
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

        public async Task CreateTurno(TurnoForCreationDto turnoDto)
        {
            await _client.PostAsJsonAsync("turni", turnoDto);
        }

        public async Task DeleteTurno(Guid turnoId)
        {
            await _client.DeleteAsync($"turni/{turnoId}");
        }

        public async Task<IEnumerable<TurnoDto>> GetAllTurni()
        {
            var turni = await _client.GetFromJsonAsync<IEnumerable<TurnoDto>>("turni");

            return turni;
        }

        public async Task<TurnoDto> GetTurnoById(Guid turnoId)
        {
            var turno = await _client.GetFromJsonAsync<TurnoDto>($"turni/{turnoId}");

            return turno;
        }

        public async Task UpdateTurno(Guid turnoId, TurnoForUpdateDto turnoDto)
        {
            await _client.PutAsJsonAsync($"turni/{turnoId}", turnoDto);
        }
    }
}