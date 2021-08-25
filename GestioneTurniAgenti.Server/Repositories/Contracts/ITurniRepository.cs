using GestioneTurniAgenti.Server.Entities;
using GestioneTurniAgenti.Server.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Server.Repositories.Contracts
{
    public interface ITurniRepository : IBaseRepository<Turno>
    {
        Task<IEnumerable<Turno>> GetByFilterWithNavigationProps(params Expression<Func<Turno, bool>>[] filters);

        Task<bool> CheckAgenteIdExistance(Guid agenteId);

        Task<bool> CheckEventoIdExistance(Guid eventoId);

        Task<bool> CheckDuplicatedTurno(Guid agenteId, Guid eventoId, DateTime data);

        Task<bool> CheckCompatibilityEventoWithData(Guid eventoId, DateTime data);
    }
}