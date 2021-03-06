using GestioneTurniAgenti.Shared.Dtos.Anagrafica;
using GestioneTurniAgenti.Shared.SearchParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Client.Services
{
    public interface IAnagraficaService
    {
        Task<IEnumerable<AgenteDto>> GetAllAgenti(AgentiSearchParameters searchParameters);

        Task<AgenteDto> GetAgenteById(Guid agenteId);

        Task<IEnumerable<RepartoDto>> GetAllReparti();

        Task<RepartoDto> GetRepartoById(Guid repartoId);
    }
}