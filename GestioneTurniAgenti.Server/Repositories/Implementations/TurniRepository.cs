using GestioneTurniAgenti.Server.Contexts;
using GestioneTurniAgenti.Server.Entities;
using GestioneTurniAgenti.Server.Repositories;
using GestioneTurniAgenti.Server.Repositories.Contracts;
using GestioneTurniAgenti.Shared.SearchParameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Server.Repositories.Implementations
{
    public class TurniRepository : BaseRepository<Turno>, ITurniRepository
    {
        private readonly GestioneTurniDbContext _context;

        public TurniRepository(GestioneTurniDbContext dbContext)
            : base(dbContext)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<bool> CheckAgenteIdExistance(Guid agenteId)
        {
            var agente = await _context.Agenti.FindAsync(agenteId);

            return agente != null;
        }

        public Task<bool> CheckCompatibilityEventoWithData(Guid eventoId, DateTime data, out (DateTime max, DateTime min) values)
        {
            var evento = _context.Eventi.FindAsync(eventoId).Result;
            values = (evento.Fine, evento.Inizio);
            if (evento == null)
            {
                return Task.FromResult(false);
            }

            if (data > evento.Fine || data < evento.Inizio)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public async Task<bool> CheckDuplicatedTurno(Guid agenteId, Guid eventoId, DateTime data)
        {
            var turno = await _context.Turni
                .FirstOrDefaultAsync(
                    t => t.AgenteId.Equals(agenteId) &&
                    t.EventoId.Equals(eventoId) &&
                    t.Data.Date.Equals(data.Date));
            return turno != null;
        }

        public async Task<bool> CheckEventoIdExistance(Guid eventoId)
        {
            var evento = await _context.Eventi.FindAsync(eventoId);

            return evento != null;
        }

        public async Task<IEnumerable<Turno>> GetTurniByParams(TurniSearchParameters parameters, bool trackChanges = false)
        {
            IQueryable<Turno> query = _context.Set<Turno>().Include(t => t.Agente).ThenInclude(a => a.Reparto).Include(t => t.Evento);

            if (parameters is null)
            {
                if (trackChanges)
                {
                    return await query.ToListAsync();
                }

                return await query.AsNoTracking().ToListAsync();
            }

            if (!string.IsNullOrWhiteSpace(parameters.AgenteNome))
            {
                query = query.Where(a => a.Agente.Nome.ToUpper().Contains(parameters.AgenteNome.Trim().ToUpper()));
            }

            if (!string.IsNullOrWhiteSpace(parameters.AgenteCognome))
            {
                query = query.Where(a => a.Agente.Cognome.ToUpper().Contains(parameters.AgenteCognome.Trim().ToUpper()));
            }

            if (!string.IsNullOrWhiteSpace(parameters.AgenteMatricola))
            {
                query = query.Where(a => a.Agente.Matricola.ToUpper().Contains(parameters.AgenteMatricola.Trim().ToUpper()));
            }

            if (parameters.EventoId != null)
            {
                query = query.Where(a => a.EventoId.Equals(parameters.EventoId));
            }

            if (parameters.RepartoId != null)
            {
                query = query.Where(a => a.Agente.RepartoId.Equals(parameters.RepartoId));
            }

            if (trackChanges)
            {
                return await query.ToListAsync();
            }

            return await query.AsNoTracking().ToListAsync();
        }
    }
}