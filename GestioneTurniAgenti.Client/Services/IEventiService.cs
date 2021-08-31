using GestioneTurniAgenti.Shared.Dtos.Eventi;
using GestioneTurniAgenti.Shared.SearchParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Client.Services
{
    public interface IEventiService
    {
        Task<IEnumerable<EventoDto>> GetAllEventi(EventiSearchParameters searchParameters);

        Task<EventoDto> GetEventoById(Guid eventoId);

        Task<string> CreateEvento(EventoForCreationDto eventoDto);

        Task<string> UpdateEvento(Guid eventoId, EventoForUpdateDto eventoDto);

        Task DeleteEvento(Guid eventoId);
    }
}