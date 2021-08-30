using GestioneTurniAgenti.Shared.Dtos.Turno;
using GestioneTurniAgenti.Shared.SearchParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Client.Services
{
    public interface ITurniService
    {
        Task<IEnumerable<TurnoDto>> GetAllTurni(TurniSearchParameters searchParameters);

        Task<TurnoDto> GetTurnoById(Guid turnoId);

        Task CreateTurno(TurnoForCreationDto turnoDto);

        Task UpdateTurno(Guid turnoId, TurnoForUpdateDto turnoDto);

        Task DeleteTurno(Guid turnoId);
    }
}