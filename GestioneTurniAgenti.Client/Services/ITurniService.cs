using GestioneTurniAgenti.Shared.Dtos.Turno;
using GestioneTurniAgenti.Shared.SearchParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Client.Services
{
    public interface ITurniService
    {
        Task<IEnumerable<TurnoDto>> GetAllTurni(TurniSearchParameters searchParameters);

        Task<TurnoDto> GetTurnoById(Guid turnoId);

        Task<string> CreateTurno(TurnoForCreationDto turnoDto);

        Task<string> UpdateTurno(Guid turnoId, TurnoForUpdateDto turnoDto);

        Task DeleteTurno(Guid turnoId);

        Task CreateFromMassivo(MultipartFormDataContent content);
    }
}