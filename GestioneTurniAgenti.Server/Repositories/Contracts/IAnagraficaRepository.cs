using GestioneTurniAgenti.Server.Entities;
using GestioneTurniAgenti.Shared.SearchParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Server.Repositories.Contracts
{
    public interface IAnagraficaRepository
    {
        Task<Agente> GetAgenteById(Guid agenteId);

        Task<IEnumerable<Agente>> GetAgenti(params Expression<Func<Agente, bool>>[] filters);

        Task<IEnumerable<Agente>> GetAgentiFromParams(AgentiSearchParameters parameters, bool trackChanges = false);

        Task<IEnumerable<Reparto>> GetReparti(params Expression<Func<Reparto, bool>>[] filters);

        Task<Reparto> GetRepartoById(Guid repartoId);

        Task<bool> Commit();
    }
}