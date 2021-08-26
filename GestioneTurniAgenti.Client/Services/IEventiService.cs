using GestioneTurniAgenti.Shared.Dtos.Eventi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Client.Services
{
    public interface IEventiService
    {
        Task<IEnumerable<EventoDto>> GetAllEventi();

        Task<EventoDto> GetEventoById(Guid eventoId);

        Task CreateEvento(EventoForCreationDto eventoDto);

        Task UpdateEvento(Guid eventoId, EventoForUpdateDto eventoDto);

        Task DeleteEvento(Guid eventoId);
    }
}