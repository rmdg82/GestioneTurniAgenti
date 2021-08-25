using GestioneTurniAgenti.Server.Contexts;
using GestioneTurniAgenti.Server.Entities;
using GestioneTurniAgenti.Server.Repositories;
using GestioneTurniAgenti.Server.Repositories.Contracts;
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

        public async Task<bool> CheckCompatibilityEventoWithData(Guid eventoId, DateTime data)
        {
            var evento = await _context.Eventi.FindAsync(eventoId);
            if (evento == null)
            {
                return false;
            }

            if (data > evento.Inizio || data < evento.Fine)
            {
                return false;
            }

            return true;
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

        public async Task<IEnumerable<Turno>> GetByFilterWithNavigationProps(params Expression<Func<Turno, bool>>[] filters)
        {
            IQueryable<Turno> query = _context.Set<Turno>();

            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            return await query.Include(t => t.Agente).Include(t => t.Evento).AsNoTracking().ToListAsync();
        }
    }
}